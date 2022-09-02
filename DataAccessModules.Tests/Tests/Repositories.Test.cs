using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Entity;
using Unir.ErpAcademico.DataAccessModules.Tests.Utils;

namespace Unir.ErpAcademico.DataAccessModules.Tests.Tests
{
    [TestClass]
    public class RepositoriesTest
    {
        private TestContext _testContextInstance;

        /// <summary>
        /// Obtiene o Establece al contesto de Pruebas
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return _testContextInstance;
            }
            set
            {
                _testContextInstance = value;
            }
        }

        [TestInitialize]
        public void TestInitialize()
        {
            Database.SetInitializer(new DddContextInitializer());
            MainUnitOfWorkTestUtils.RestartUnitOfWork();
        }

        [AssemblyInitialize]
        public static void AssemblyInitialize(TestContext context)
        {
            if (Database.Exists("TestDatabase"))
                Database.Delete("TestDatabase");
        }
    }
}
