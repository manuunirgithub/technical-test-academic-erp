using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Unir.Architecture.SuperTypes.PresentationBase.Controllers;

namespace Unir.ErpAcademico.WebCapacitaciones.Controllers
{
    public class HomeController : ControllerSuperType
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
