using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WepApp.Models;

namespace WepApp.Infrastructure
{
    public interface IPeopleService
    {
        void Insert(People entity);

        void Delete(People entity);

        void Update(People entity);

        People GetById(int Id);

        IEnumerable<People> GetMany(Expression<Func<People, bool>> where);

        IEnumerable<People> GetAll();

        int Count();
    }

    public class PeopleService : IPeopleService
    {
        private readonly PeopleContext _context;


        public PeopleService(PeopleContext context)
        {
            this._context = context;
        }

        public int Count()
        {
            return this._context.Peoples.Count();
        }

        public void Delete(People entity)
        {
            this._context.Remove(entity);
            this._context.SaveChanges();
        }

        public IEnumerable<People> GetAll()
        {
            return _context.Peoples;
        }

        public People GetById(int Id)
        {
           return _context.Peoples.Where(c => c.Id == Id).FirstOrDefault();
        }

        public IEnumerable<People> GetMany(Expression<Func<People, bool>> where)
        {
           return _context.Peoples.Where(where);
        }

        public void Insert(People entity)
        {
            _context.Peoples.Add(entity);
        }

        public void Update(People entity)
        {
            _context.Peoples.Update(entity);
            _context.SaveChanges();
        }
    }
}
