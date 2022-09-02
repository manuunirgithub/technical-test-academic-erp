using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using Unir.Architecture.SuperTypes.DomainBase;

namespace Unir.ErpAcademico.DataAccessModules.Tests.Utils
{
    public static class MainUnitOfWorkTestUtils
    {
        private static readonly string ConnectionString = ConfigurationManager.ConnectionStrings["TestDatabase"].ConnectionString;

        private static MainUnitOfWork _unitOfWork;

        public static MainUnitOfWork GetUnitOfWork()
        {
            if (_unitOfWork == null)
            {
                _unitOfWork = new MainUnitOfWork(ConnectionString);
                _unitOfWork.Configuration.ValidateOnSaveEnabled = false;
            }
            return _unitOfWork;
        }
        public static void RestartUnitOfWork()
        {
            if (_unitOfWork != null)
                _unitOfWork.Dispose();

            _unitOfWork = new MainUnitOfWork(ConnectionString);
        }

        private static int _lastCountId;
        private static readonly Dictionary<Type, IComparable> MainIdCount = new Dictionary<Type, IComparable>();
        public static IComparable GetNextId<T, TId, TRep>(Func<TRep> getRepoAction)
            where T : Entity<TId>
            where TId : IEquatable<TId>, IComparable<TId>
            where TRep : IRepository<T, TId>
        {
            if (typeof (TId) == typeof (string))
                return Guid.NewGuid().ToString();
            if (typeof (TId) != typeof (int))
                throw new Exception("Solo se admiten tipos int y String");

            var last = getRepoAction.Invoke()
                        .GetPagedFiltered(f => true, 1, 1, new OrderByExpression<T, TId>(o => o.Id, false))
                        .Elements.FirstOrDefault();

            var count = MainIdCount.ContainsKey(typeof (T))
                            ? (int)MainIdCount[typeof (T)]
                            : 0;

            // Establcer una nuevo valor al contador por tipo.
            if (count == 0)
            {
                if (last != null)
                    count = int.Parse(last.Id.ToString()) + 1;
                else
                    count = 1;
            }
            else
            {
                count++;
            }

            // Asegurara la "unicidad" de los ids asignados.
            if (count <= _lastCountId)
            {
                _lastCountId++;
                count = _lastCountId;
            }
            else
            {
                _lastCountId = count;
            }

            MainIdCount[typeof (T)] = count;
            return count;
        }  
    }
}
