//------------------------------------------------------------------------------
// <safe-for-custom-code>
//     This code file was provided by Radarc (http://radarc.net) - Radarc version: 4.9.1.22813 Formula: UNIR.1.1 version: 1.1
//
//     It is safe to add and maintain your custom code here. Radarc will not override it unless this file is missing.
// </safe-for-custom-code>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace Unir.ErpAcademico.DataAccessModules
{
    public class DddContextInitializer : DropCreateDatabaseIfModelChanges<MainUnitOfWork>
    {
        protected override void Seed(MainUnitOfWork context)
        {
		}
	}
}
