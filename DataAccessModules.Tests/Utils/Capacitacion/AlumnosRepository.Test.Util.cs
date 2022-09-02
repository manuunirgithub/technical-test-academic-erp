//------------------------------------------------------------------------------
// <safe-for-custom-code>
//     This code file was provided by Radarc (http://radarc.net) - Radarc version: 4.9.1.22813 Formula: UNIR.1.1 version: 1.1
//
//     It is safe to add and maintain your custom code here. Radarc will not override it unless this file is missing.
// </safe-for-custom-code>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unir.ErpAcademico.DataAccessModules.Tests.Utils;
using Unir.ErpAcademico.DataAccessModules.Capacitacion.Repositories;
using Unir.ErpAcademico.DomainModules.Capacitacion.Aggregates.Alumnos;

namespace Unir.ErpAcademico.DataAccessModules.Tests.Utils.Capacitacion
{
    public class AlumnosRepositoryTestUtil : AlumnosRepositoryTestUtilBase
    {
		public static AlumnosRepositoryTestUtil GetInstance()
		{
			return new AlumnosRepositoryTestUtil();
		}
    }
}

