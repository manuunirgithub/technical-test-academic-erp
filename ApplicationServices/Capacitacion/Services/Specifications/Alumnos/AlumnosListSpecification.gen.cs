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
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Unir.Architecture.SuperTypes.ApplicationServicesBase.AppServicesUtility;
using Unir.Architecture.SuperTypes.DomainBase;
using Unir.Architecture.SuperTypes.DomainBase.Specification;
using Unir.ErpAcademico.DomainModules.Capacitacion.Aggregates.Alumnos;
using Unir.ErpAcademico.ApplicationServices.Capacitacion.Dto.Alumnos;

namespace Unir.ErpAcademico.ApplicationServices.Capacitacion.Services.Specifications.Alumnos
{
    public class AlumnosListSpecificationBase
        : PagedListSpecification<Alumno, int, AlumnoDto, AlumnosOrderColumn>
    {
        public virtual string FilterNombres { get; set; }
        public virtual string FilterApellidos { get; set; }
        public virtual string FilterNombresApellidos { get; set; }


        public virtual RangeFilterValues<DateTime?> FilterFechaNacimiento { get; set; }

        private Specification<Alumno> _filter;
        private ProjectionSpecification<Alumno, int, AlumnoDto> _projection;
        private List<IOrderByExpression<Alumno>> _ordenation;

        public AlumnosListSpecificationBase()
        {
            FilterFechaNacimiento = new RangeFilterValues<DateTime?>();
        }

        public override Specification<Alumno> FilterSpecification
        {
            get
            {
                if (_filter == null)
                {
                    // Expresión de Filtrado
                    Specification<Alumno> filterSpec = new TrueSpecification<Alumno>();

                    // *** Filtros Simples (Text Filters)
                    // Nombres
                    if (!string.IsNullOrEmpty(FilterNombres))
                        filterSpec &= new DirectSpecification<Alumno>(a => (a.Nombres.Contains(FilterNombres)));
                    // Apellidos
                    if (!string.IsNullOrEmpty(FilterApellidos))
                        filterSpec &= new DirectSpecification<Alumno>(a => (a.Apellidos.Contains(FilterApellidos)));

                    // Nombre Completo (Nombres y Apellidos)
                    if (!string.IsNullOrEmpty(FilterNombresApellidos))
                        filterSpec &= new DirectSpecification<Alumno>(
                                a => (
                                    a.Nombres.ToLower().Contains(FilterNombresApellidos.ToLower()) || 
                                    a.Apellidos.ToLower().Contains(FilterNombresApellidos.ToLower())
                                )
                         );


                    // *** Filters de Rango (Range Filters)
                    // FechaNacimiento
                    if (FilterFechaNacimiento.From.HasValue)
                    {
                        var auxFrom = FilterFechaNacimiento.From.Value.Date;
                        filterSpec &= new DirectSpecification<Alumno>(a => a.FechaNacimiento.HasValue && a.FechaNacimiento.Value >= auxFrom);
                    }

                    if (FilterFechaNacimiento.To.HasValue)
                    {
                        var auxTo = FilterFechaNacimiento.To.Value.Date.AddDays(1);
                        filterSpec &= new DirectSpecification<Alumno>(a => a.FechaNacimiento.HasValue && a.FechaNacimiento.Value < auxTo);
                    }

                    _filter = filterSpec;
                }
                return _filter;
            }
            set { _filter = value; }
        }

        public override ProjectionSpecification<Alumno, int, AlumnoDto> ProjectionSpecification
        {
            get
            {
                return _projection ?? (
                    _projection = new ProjectionSpecification<Alumno, int, AlumnoDto>(a => new AlumnoDto
                    {
                        Id = a.Id,
                        Nombres = a.Nombres,
                        Apellidos = a.Apellidos,
                        FechaNacimiento = a.FechaNacimiento,
                    }));
            }
            set
            {
                _projection = value;
            }
        }

        public override List<IOrderByExpression<Alumno>> OrderByExpressions
        {
            get
            {
                if (_ordenation == null || !_ordenation.Any())
                {
                    if (Pagination == null)
                        throw new Exception("Falta establecer información de Paginación.");

                    _ordenation = new List<IOrderByExpression<Alumno>>();

                    // Expresión de Ordenación
                    foreach (var orderColumn in Pagination.OrderColumns)
                    {
                        switch (orderColumn.Column)
                        {
                            case AlumnosOrderColumn.Nombres:
                                _ordenation.Add(new OrderByExpression<Alumno, string>(a => a.Nombres, orderColumn.AscendingDirection));
                                break;
                            case AlumnosOrderColumn.Apellidos:
                                _ordenation.Add(new OrderByExpression<Alumno, string>(a => a.Apellidos, orderColumn.AscendingDirection));
                                break;
                            case AlumnosOrderColumn.FechaNacimiento:
                                _ordenation.Add(new OrderByExpression<Alumno, DateTime?>(a => a.FechaNacimiento, orderColumn.AscendingDirection));
                                break;
                            default:
                                _ordenation.Add(new OrderByExpression<Alumno, int>(a => a.Id, orderColumn.AscendingDirection));
                                break;
                        }
                    }
                }
                return _ordenation;
            }
            set
            {
                _ordenation = value;
            }
        }
    }
}