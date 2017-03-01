using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WepApp.Models;

namespace WepApp.Infrastructure
{
    public abstract class RepositoryBase<T> : IRepository<T> where T : class
    {
        #region Filed

        private PeopleContext dataContext;
        private DbSet<T> dbSet;
        #endregion Filed

        #region Ctr

        protected RepositoryBase(PeopleContext dataContext)
        {
            this.dataContext = dataContext;
            dbSet = dataContext.Set<T>();
        }

        #endregion Ctr

        public virtual void Insert(T entity)
        {
            dbSet.Add(entity);
            dataContext.SaveChanges();
        }

        public virtual void Update(T entity)
        {
            dbSet.Attach(entity);
            dataContext.Entry(entity).State = EntityState.Modified;
            dataContext.SaveChanges();
        }

        public virtual void Delete(T entity)
        {
            dbSet.Remove(entity);
            dataContext.SaveChanges();
        }

        public virtual async Task<IEnumerable<T>> GetAll()
        {
            return await dataContext.Set<T>().ToListAsync();
        }

        public virtual T GetById(Expression<Func<T, bool>> where)
        {
            return dbSet.Where(where).FirstOrDefault();
        }

        public virtual IEnumerable<T> GetMany(Expression<Func<T, bool>> where)
        {
            return dbSet.Where(where);
        }
        public virtual int Count()
        {
            return dbSet.Count();
        }
    }
}