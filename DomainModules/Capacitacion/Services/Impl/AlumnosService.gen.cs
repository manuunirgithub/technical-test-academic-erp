//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Radarc (http://radarc.net) - Radarc version: 4.9.1.22813 Formula: UNIR.1.1 version: 1.1
//
//     Changes to this file may cause incorrect behavior and will be lost if the code is regenerated. 
//     If you want to extend or modify the code use the designated extension points / user escapes as described in the product documentation.
// </auto-generated>
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
using Unir.ErpAcademico.DomainModules.Capacitacion.Aggregates.Alumnos;

namespace Unir.ErpAcademico.DomainModules.Capacitacion.Services.Impl
{
    public partial class AlumnosServiceBase
    {
        protected readonly IAlumnosRepository RepoAlumnos;

        public AlumnosServiceBase(IAlumnosRepository repoAlumnos)
        {
            if (repoAlumnos == null) throw new ArgumentNullException("repoAlumnos");
				RepoAlumnos = repoAlumnos;
        }
		
	
    }
}
