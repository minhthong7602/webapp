using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace WepApp.Infrastructure
{
    public interface IRepository<T> where T : class
    {
        void Insert(T entity);

        void Delete(T entity);

        void Update(T entity);

        T GetById(Expression<Func<T, bool>> where);

        IEnumerable<T> GetMany(Expression<Func<T, bool>> where);

        Task<IEnumerable<T>> GetAll();

        int Count();
    }
}
