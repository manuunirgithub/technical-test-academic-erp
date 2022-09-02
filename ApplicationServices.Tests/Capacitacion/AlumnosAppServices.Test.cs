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
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Unir.Architecture.SuperTypes.ApplicationServicesBase;
using Unir.Architecture.SuperTypes.ApplicationServicesBase.AppServicesUtility;
using Unir.Architecture.SuperTypes.DomainBase.Specification;
using Unir.ErpAcademico.ApplicationServices.Capacitacion.Services;
using Unir.ErpAcademico.ApplicationServices.Capacitacion.Services.Impl;
using Unir.ErpAcademico.ApplicationServices.Capacitacion.Dto.Alumnos;
using Unir.ErpAcademico.ApplicationServices.Capacitacion.Services.Specifications.Alumnos;
using Unir.ErpAcademico.DomainModules.Capacitacion.Aggregates.Alumnos;
using Unir.ErpAcademico.DataAccessModules.Tests.Utils.Capacitacion;

namespace Unir.ErpAcademico.ApplicationServices.Tests.Capacitacion
{
    [TestClass]
    public class AlumnosAppServicesTest : AppServicesTest
    {
        private static IAlumnosAppServices CreateAlumnosAppServices()
        {
		    return GetAppServicesInstance(typeof(AlumnosAppServices)) as AlumnosAppServices;
        }

        #region Listado Principal
		
		[TestMethod]
        public void GetPagedAlumnosFilterTest()
        {
            var target = CreateAlumnosAppServices();

            // Añadir 15 Alumnos.-
            var testList = new List<Alumno>();
            for (var i = 1; i <= 15; i++)
            {
                testList.Add(AlumnosRepositoryTestUtil.GetInstance().CreateAlumno());
            }

            var first = testList.First();
            var middle = testList[10];
            var last = testList.Last();

            var specification = new AlumnosListSpecification();
            specification.FilterSpecification = 
                new DirectSpecification<Alumno>(e => e.Id == first.Id
                                                  || e.Id == middle.Id
                                                  || e.Id == last.Id);
            
            specification.Pagination = new Pagination<AlumnosOrderColumn>();
            specification.Pagination.AddOrderColumn(AlumnosOrderColumn.Id, OrderDirection.Ascending);
            specification.Pagination.PageIndex = 1;
            specification.Pagination.PageCount = 5;

            // Probar paginación.
            var actual = target.GetPagedAlumnos(specification);
            Assert.IsFalse(actual.HasErrors, "Resultado de listar con errores: " + string.Join("; ", actual.Errors));
            Assert.IsTrue(actual.TotalElements == 3 && actual.TotalPages == 1, "Valor de TotalElements y/o TotalPages incorrecto.");

            Assert.IsNotNull(actual.Elements.SingleOrDefault(e => e.Id == first.Id), "No se encontró elemento");
            Assert.IsNotNull(actual.Elements.SingleOrDefault(e => e.Id == middle.Id), "No se encontró elemento");
            Assert.IsNotNull(actual.Elements.SingleOrDefault(e => e.Id == last.Id), "No se encontró elemento");
        }

        [TestMethod]
        public void GetAlumnoTest()
        {
            var target = CreateAlumnosAppServices();

            var alumno = AlumnosRepositoryTestUtil.GetInstance().CreateAlumno();

            var actual = target.GetAlumno(alumno.Id);

            Assert.IsFalse(actual.HasErrors, "Errores al intentar obtener Alumno: " + string.Join(";", actual.Errors));
            Assert.IsNotNull(actual.Element, "El elemento Alumno resultante es null");
            Assert.IsTrue(actual.Element.Id == alumno.Id, "El elemento Alumno resultante es incorrecto");
        }

        #endregion Listado Principal		

        #region Persistencia
		
        [TestMethod]
        public void NewAlumnoTest()
        {
            var target = CreateAlumnosAppServices();
            var repoAlumnos = AlumnosRepositoryTestUtil.GetInstance().CreateAlumnosRepository();

            var alumno = AlumnosRepositoryTestUtil.GetInstance().GetAlumno();

            // Proyección automática de Dtos.
            var alumnoDto = alumno.ProjectedAs<AlumnoDto>();

            var result = target.NewAlumno(alumnoDto);
            
            Assert.IsFalse(result.HasErrors, "Errores durante la creación de Alumno: " + string.Join(";", result.Errors));
            Assert.IsNotNull(result.Element, "Elemento resultante de la creación de Alumno es null");

            var elementAdded = repoAlumnos.Get(result.Element.Id);
            Assert.IsNotNull(elementAdded, "No se agregó ningún nuevo elemento Alumno en la Base de Datos.");
        }

        [TestMethod]
        public void ModifyAlumnoTest()
        {
            var target = CreateAlumnosAppServices();

            var alumno = AlumnosRepositoryTestUtil.GetInstance().CreateAlumno();
            var actual = target.GetAlumno(alumno.Id);
            Assert.IsFalse(actual.HasErrors, "Errores al obtener un Alumno");

            var modifyProp =  Guid.NewGuid().ToString();
            actual.Element.Nombres = modifyProp;
            var resultModif = target.ModifyAlumno(actual.Element);

            actual = target.GetAlumno(alumno.Id);

            Assert.IsFalse(resultModif.HasErrors, "Errores en resultado de la Modificación" + string.Join(";", resultModif.Errors));
            Assert.IsTrue(actual.Element.Nombres == modifyProp, "La propiedad no se modificó correctamente.");
        }

        [TestMethod]
        public void DeleteAlumnoTest()
        {
            var target = CreateAlumnosAppServices();

            var alumno1 = AlumnosRepositoryTestUtil.GetInstance().CreateAlumno();
            var alumno2 = AlumnosRepositoryTestUtil.GetInstance().CreateAlumno();

            target.DeleteAlumnos(new [] {alumno1.Id, alumno2.Id});

            var alumno1Result = target.GetAlumno(alumno1.Id);
            var alumno2Result = target.GetAlumno(alumno2.Id);

            Assert.IsNull(alumno1Result.Element, "El elemento se pudo recuperar luego de ser supuestamente eliminado.");
            Assert.IsNull(alumno2Result.Element, "El elemento se pudo recuperar luego de ser supuestamente eliminado.");

            Assert.IsTrue(alumno1Result.HasErrors, "El elemento se pudo recuperar luego de ser supuestamente eliminado.");
            Assert.IsTrue(alumno2Result.HasErrors, "El elemento se pudo recuperar luego de ser supuestamente eliminado.");
        }
        [TestMethod]
        public void CloneAlumnoTest()
        {
            var target = CreateAlumnosAppServices();

            var alumno1 = AlumnosRepositoryTestUtil.GetInstance().CreateAlumno();
            var alumno2 = AlumnosRepositoryTestUtil.GetInstance().CreateAlumno();

            var newIds = target.CloneAlumnos(new[] {alumno1.Id, alumno2.Id});

            Assert.IsNotNull(newIds.Value, "Error resultado del procedimiento de clonación");
            Assert.IsFalse(newIds.HasErrors, "Error resultado del procedimiento de clonación");
            Assert.IsTrue(newIds.Value.Length == 2, "Error resultado del procedimiento de clonación");

            var repoAlumnos = AlumnosRepositoryTestUtil.GetInstance().CreateAlumnosRepository();

            var clone1 = repoAlumnos.Get(newIds.Value[0]);
            var clone2 = repoAlumnos.Get(newIds.Value[1]);

            Assert.IsNotNull(clone1, "Objeto no clonado");
            Assert.IsNotNull(clone2, "Objeto no clonado");

            // Clon 1
            Assert.IsTrue(alumno1.Nombres == clone1.Nombres, "Propiedad Nombres incorrectamente copiada");
            Assert.IsTrue(alumno1.Apellidos == clone1.Apellidos, "Propiedad Apellidos incorrectamente copiada");
            // Clon 2
            Assert.IsTrue(alumno2.Nombres == clone2.Nombres, "Propiedad Nombres incorrectamente copiada");
            Assert.IsTrue(alumno2.Apellidos == clone2.Apellidos, "Propiedad Apellidos incorrectamente copiada");
        }

        #endregion Persistencia		
    }
}
