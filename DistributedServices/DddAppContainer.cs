//------------------------------------------------------------------------------
// <safe-for-custom-code>
//     This code file was provided by Radarc (http://radarc.net) - Radarc version: 4.9.1.22813 Formula: UNIR.1.1 version: 1.1
//
//     It is safe to add and maintain your custom code here. Radarc will not override it unless this file is missing.
// </safe-for-custom-code>
//------------------------------------------------------------------------------
using System;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using Unir.Architecture.SuperTypes.DataAccessBase;
using Unir.Architecture.SuperTypes.DistributedServicesBase;
using Unir.ErpAcademico.DataAccessModules;
using Autofac;


namespace Unir.ErpAcademico.DistributedServices
{
    public class DddAppContainer : DddAppContainerBase
    {
        public DddAppContainer(Action<ContainerBuilder> builderAction) : base(builderAction)
        {
            
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<MainUnitOfWork>());
        }
	}
}
