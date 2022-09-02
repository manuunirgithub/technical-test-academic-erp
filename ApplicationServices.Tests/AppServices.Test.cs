//------------------------------------------------------------------------------
// <safe-for-custom-code>
//     This code file was provided by Radarc (http://radarc.net) - Radarc version: 4.9.1.22813 Formula: UNIR.1.1 version: 1.1
//
//     It is safe to add and maintain your custom code here. Radarc will not override it unless this file is missing.
// </safe-for-custom-code>
//------------------------------------------------------------------------------
using System;
using System.Linq;
using System.Collections.Generic;
using System.Data.Entity;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Unir.Architecture.SuperTypes.DomainBase;
using Unir.Architecture.SuperTypes.DomainBase.Extensions;
using Unir.Architecture.SuperTypes.ApplicationServicesBase;
using Unir.Architecture.Crosscutting.Adapters;
using Unir.Architecture.Crosscutting.NetImpl.Adapters;
using Unir.Architecture.Crosscutting.AppDataCache;
using Unir.Architecture.Crosscutting.Audit;
using Unir.Architecture.Crosscutting.BackgroundJobs;
using Unir.Architecture.Crosscutting.Bus;
using Unir.Architecture.Crosscutting.Email;
using Unir.Architecture.Crosscutting.FileManagement;
using Unir.Architecture.Crosscutting.Navigation;
using Unir.Architecture.Crosscutting.Notes;
using Unir.Architecture.Crosscutting.Security;
using Unir.ErpAcademico.DataAccessModules;
using Unir.ErpAcademico.DataAccessModules.Tests.Utils;

namespace Unir.ErpAcademico.ApplicationServices.Tests
{
    [TestClass]
    public partial class AppServicesTest
    {
	    private static Dictionary<Type, KeyValuePair<MethodInfo, MethodInfo>> _testReposTypes = new Dictionary<Type, KeyValuePair<MethodInfo, MethodInfo>>();
        private static Dictionary<Type, MethodInfo> _testAppServicesTypes = new Dictionary<Type, MethodInfo>();
	
        [AssemblyInitialize]
        public static void TestAssemblyInitialize(TestContext context)
        {
            if (Database.Exists("TestDatabase"))
                Database.Delete("TestDatabase");
				
            TypeAdapterFactory.SetCurrentFactory(
                new AutomapperTypeAdapterFactory(typeof(Unir.ErpAcademico.ApplicationServices.Capacitacion.Services.IAlumnosAppServices).Assembly));
            // Inicializar tipos de RepositoryTest.
            _testReposTypes =
                typeof(MainUnitOfWorkTestUtils).Assembly.DefinedTypes.Where(t => t.Name.EndsWith("RepositoryTestUtil"))
                    .ToDictionary(
                        d =>
                        {
                            var createMethod = d.GetMethods().FirstOrDefault(m => m.Name.StartsWith("Create") && m.Name.EndsWith("Repository"));
                            if (createMethod == null)
                            {
                                throw new Exception(string.Format("El Tipo {0} no tienen ningún metodo Create...", d));
                            }

                            return createMethod.ReturnType;
                        },
                        d => new KeyValuePair<MethodInfo, MethodInfo>(
                                d.GetMethod("GetInstance"),
                                d.GetMethods().FirstOrDefault(m => m.Name.StartsWith("Create") && m.Name.EndsWith("Repository"))));

            _testAppServicesTypes =
                typeof(AppServicesTest).Assembly.DefinedTypes.Where(
                    t => t.Name.EndsWith("AppServicesTest")
                      && t.IsDerivedFromType(typeof(AppServicesTest))
                      && t != typeof(AppServicesTest)
                      && t.GetMethods().Any(m => m.Name.StartsWith("Create") && m.Name.EndsWith("AppServices") && !m.GetParameters().Any()))
                    .ToDictionary(
                        d => d.GetMethods().FirstOrDefault(m => m.Name.StartsWith("Create") && m.Name.EndsWith("AppServices") && !m.GetParameters().Any()).ReturnType,
                        d => d.GetMethods().FirstOrDefault(m => m.Name.StartsWith("Create") && m.Name.EndsWith("AppServices") && !m.GetParameters().Any()));
        }

        [TestInitialize]
        public void TestInitialize()
        {
            Database.SetInitializer(new DddContextInitializer());
            MainUnitOfWorkTestUtils.RestartUnitOfWork();
        }
		
        protected static object GetAppServicesInstance(Type appServicesType)
        {
            return GetAppServicesInstance(appServicesType, new Dictionary<string, object>());
        }
        protected static object GetAppServicesInstance(Type appServicesType, Dictionary<string, object> extraParams)
        {
            object resultInstance;
            var constructor = appServicesType.GetConstructors().OrderByDescending(c => c.GetParameters().Count()).FirstOrDefault();

            var repoResolver = new TestRepositoryResolver();

            if (constructor != null)
            {

                var testInstances = new List<object>();
                foreach (var parameterInfo in constructor.GetParameters())
                {
                    if (parameterInfo.ParameterType.IsDerivedFromGenericType(typeof (IRepository<,>)))
                    {
                        testInstances.Add(repoResolver.Resolve(parameterInfo.ParameterType));
                    }
                    else if (parameterInfo.ParameterType.FullName.EndsWith("Services"))
                    {
                        var name = parameterInfo.ParameterType.Namespace + ".Impl." +
                                   parameterInfo.ParameterType.Name.Substring(1) + ", " +
                                   parameterInfo.ParameterType.Assembly.FullName;
                        var implType = Type.GetType(name);
                        testInstances.Add(GetAppServicesInstance(implType, extraParams));
                    }
                    else if (extraParams.ContainsKey(parameterInfo.Name))
                    {
                        testInstances.Add(extraParams[parameterInfo.Name]);
                    }
                    else
                    {
                        throw new Exception(
                            string.Format(
                                "Hay en el constructor por defecto de este Servicio de Aplicación, un argumento de tipo no permitido ({0}) que no es ni ICommonApplicationServices ni IRepository, o bien es IRepository pero no tiene disponible un TestUtil. Tampoco está definido como un 'extraParam'",
                                parameterInfo.ParameterType.Name));
                    }
                }
                resultInstance = Activator.CreateInstance(appServicesType, testInstances.ToArray());
            }
            else
            {
                resultInstance = Activator.CreateInstance(appServicesType);
            }

            ((ICommonApplicationServices)resultInstance).RepositoryResolver = repoResolver;

			// Inicialización rápida de Mocks
            ((ICommonApplicationServices)resultInstance).FileManager = new Mock<IFileManager>().Object;
            ((ICommonApplicationServices)resultInstance).SecurityService = new Mock<ISecurityService>().Object;
            ((ICommonApplicationServices)resultInstance).BackgroundJobService = new Mock<IBackgroundJobService>().Object;
            ((ICommonApplicationServices)resultInstance).Bus = new Mock<IBus>().Object;
            ((ICommonApplicationServices)resultInstance).DataCacheService = new Mock<IDataCacheService>().Object;
            ((ICommonApplicationServices)resultInstance).MailSender = new Mock<IMailSenderService>().Object;
            ((ICommonApplicationServices)resultInstance).NavigationService = new Mock<INavigationService>().Object;
            ((ICommonApplicationServices)resultInstance).NotesService = new Mock<INotesService>().Object;
            ((ICommonApplicationServices)resultInstance).ExternalAccessBuilder = new Mock<IExternalAccessBuilder>().Object;
			
            return resultInstance;
        }

        class TestRepositoryResolver : IRepositoryResolver
        {
            public T Resolve<T>() where T : IRepositoryBase
            {
                return (T) Resolve(typeof(T));
            }
            public object Resolve(Type type)
            {
                if (_testReposTypes.ContainsKey(type))
                {
                    var instanceMethod = _testReposTypes[type].Key;
                    var createMethod = _testReposTypes[type].Value;

                    var utilInstance = instanceMethod.Invoke(null, null);
                    return createMethod.Invoke(utilInstance, null);
                }
                throw new Exception(
                    string.Format("No se ha podido encontrar Utilitario para resolver la Implmentación de Pruebas Unitarias para el Repositorio: {0}", type.Name));

            }
        }
    }
}
