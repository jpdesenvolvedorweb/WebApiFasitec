using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace WebAppFasitec.Repository
{
    public interface IRepository<T>
    {
        IQueryable<T> Get();

        T GetById(Expression<Func<T, bool>> predicate);

        void Add(T entity);

        void AddRange(IEnumerable<T> entity);

        void Update(T entity);

        void Delete(T entity);
    }
}
