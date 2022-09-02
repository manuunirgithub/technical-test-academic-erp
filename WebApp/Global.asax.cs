using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.WebPages;
using Autofac;
using RazorGenerator.Mvc;
using Unir.Architecture.SuperTypes.PresentationBase;
using Unir.Architecture.SuperTypes.DistributedServicesBase;
using Unir.ErpAcademico.DistributedServices;
using Unir.ErpAcademico.WebCapacitaciones.Bundles;

namespace Unir.ErpAcademico.WebCapacitaciones
{
    public class WebApplication : MvcPresentationLayerBase<DddAppContainer>
    {
        protected override void Application_Start()
        {
            base.Application_Start();

            // Registrar la ruta por defecto
            RegisterDefaultRoute("Authentication", "Login");

            var engine = new PrecompiledMvcEngine(typeof(Unir.VisualComponents.ComponentsViews.ComponentView).Assembly);

            ViewEngines.Engines.Add(engine);
            VirtualPathFactoryManager.RegisterVirtualPathFactory(engine);

            ControllerBuilder.Current.DefaultNamespaces.Add("Unir.VisualComponents.Controllers");

            Bundles.Bundles.RegisterBundles(BundleTable.Bundles);

            new AutoMapper.AutoMapperConfigurationException("");

        }
    }
}