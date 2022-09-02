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
using Unir.Architecture.SuperTypes.DataAccessBase;
using Unir.Architecture.SuperTypes.DomainBase;
using Unir.Architecture.SuperTypes.DomainBase.ActionResult;
using Unir.Architecture.SuperTypes.DomainBase.Extensions;
using Unir.ErpAcademico.DomainModules.Capacitacion.Aggregates.Alumnos;

namespace Unir.ErpAcademico.DataAccessModules.Capacitacion.Repositories
{
    public partial class AlumnosRepository
		: GenericRepository<Alumno, int>, IAlumnosRepository
    {
        public AlumnosRepository(IQueryableUnitOfWork unitOfWork)
            : base(unitOfWork) { }
	}
}
