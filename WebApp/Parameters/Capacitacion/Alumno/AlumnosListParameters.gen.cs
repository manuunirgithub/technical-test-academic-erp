//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Radarc (http://radarc.net) - Radarc version: 4.9.1.22813 Formula: UNIR.1.1 version: 1.1
//
//     Changes to this file may cause incorrect behavior and will be lost if the code is regenerated. 
//     If you want to extend or modify the code use the designated extension points / user escapes as described in the product documentation.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using Unir.Architecture.SuperTypes.PresentationBase.ActionsParameters;

namespace Unir.ErpAcademico.WebCapacitaciones.Parameters.Capacitacion.Alumno
{
	public class AlumnosListParametersBase : ListActionParameters
    {
        #region Filtros Textos

        public string FilterNombres { get; set; }
        public string FilterApellidos { get; set; }
        public string FilterNombresApellidos { get; set; }
        
        #endregion
		
        #region Filtros Rango Propiedades Escalares

        public DateTime? FilterFechaNacimientoFrom { get; set; }
        public DateTime? FilterFechaNacimientoTo { get; set; }
        
        #endregion
	}
}
