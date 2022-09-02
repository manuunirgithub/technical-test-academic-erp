using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Unir.Architecture.SuperTypes.PresentationBase.Controllers;

namespace Unir.ErpAcademico.WebCapacitaciones.Controllers
{
    public class AuthenticationController : ControllerSuperType
    {
        [HttpGet]
        public ActionResult Login()
        {
            var resultLogin = SecurityService.LoginAccount("test-user", "test-user");
            if (resultLogin)
            {
                return RedirectToAction("Index", "Home");
            }
            return RedirectToError(string.Empty);
        }
    }
}
