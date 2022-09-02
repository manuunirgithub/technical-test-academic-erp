//------------------------------------------------------------------------------
// <safe-for-custom-code>
//     This code file was provided by Radarc (http://radarc.net) - Radarc version: 4.9.1.22813 Formula: UNIR.1.1 version: 1.1
//
//     It is safe to add and maintain your custom code here. Radarc will not override it unless this file is missing.
// </safe-for-custom-code>
//------------------------------------------------------------------------------

using System.Web.Optimization;

namespace Unir.ErpAcademico.WebCapacitaciones.Bundles.Capacitacion
{
	public class AlumnoBundle : AlumnoBundleBase
    {
        public static AlumnoBundle GetInstance()
        {
            return new AlumnoBundle();
        }


    }
}
