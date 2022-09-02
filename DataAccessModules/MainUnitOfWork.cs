//------------------------------------------------------------------------------
// <safe-for-custom-code>
//     This code file was provided by Radarc (http://radarc.net) - Radarc version: 4.9.1.22813 Formula: UNIR.1.1 version: 1.1
//
//     It is safe to add and maintain your custom code here. Radarc will not override it unless this file is missing.
// </safe-for-custom-code>
//------------------------------------------------------------------------------
using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using Unir.Architecture.SuperTypes.DomainBase;
using Unir.Architecture.SuperTypes.DomainBase.ActionResult;
using Unir.Architecture.SuperTypes.DomainBase.Extensions;
using Unir.Architecture.SuperTypes.DataAccessBase;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;
namespace Unir.ErpAcademico.DataAccessModules
{
    public class MainUnitOfWork
        : MainUnitOfWorkBase
    {
        public MainUnitOfWork(DbConnection connection)
            : base(connection) { }
        public MainUnitOfWork(string connectionString)
            : base(connectionString) { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
		}
	}
}
