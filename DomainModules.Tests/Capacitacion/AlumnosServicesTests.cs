//------------------------------------------------------------------------------
// <safe-for-custom-code>
//     This code file was provided by Radarc (http://radarc.net) - Radarc version: 4.9.1.22813 Formula: UNIR.1.1 version: 1.1
//
//     It is safe to add and maintain your custom code here. Radarc will not override it unless this file is missing.
// </safe-for-custom-code>
//------------------------------------------------------------------------------
using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Unir.ErpAcademico.DomainModules.Tests.Capacitacion
{
    /// <summary>
    /// Descripción resumida de AlumnosServicesTest
    /// </summary>
    [TestClass]
    public class AlumnosServicesTest
    {
        public AlumnosServicesTest()
        {
            //
            // TODO: Agregar aquí la lógica del constructor
            //
        }

        private TestContext _testContextInstance;

        ///<summary>
        ///Obtiene o establece el contexto de las pruebas que proporciona
        ///información y funcionalidad para la ejecución de pruebas actual.
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
    }
}
