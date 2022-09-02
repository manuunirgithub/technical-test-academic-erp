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
using System.Web.Http;
using System.Web.Http.Description;
using Unir.Architecture.SuperTypes.PresentationBase.Controllers;
using Unir.ErpAcademico.ApplicationServices.Capacitacion.Dto.Alumnos;
using Unir.ErpAcademico.ApplicationServices.Capacitacion.Services;
using Unir.ErpAcademico.ApplicationServices.Capacitacion.Services.Specifications.Alumnos;
using Unir.ErpAcademico.WebCapacitaciones.Parameters.Capacitacion.Alumno;

namespace Unir.ErpAcademico.WebCapacitaciones.ApiControllers.Capacitacion
{
	[RoutePrefix("api/v1/alumnos")]
	public class AlumnoController : AlumnoControllerBase
	{
        public AlumnoController(IAlumnosAppServices servicesAlumnos) : base(servicesAlumnos)
        {
        }
	
	}
}
