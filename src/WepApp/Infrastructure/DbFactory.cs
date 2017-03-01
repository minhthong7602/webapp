using System;
using WepApp.Models;

namespace WepApp.Infrastructure
{
    public class DbFactory : Disposeable, IDbFactory 
    {
        private PeopleContext dbContext;

        public DbFactory(PeopleContext _dbContext)
        {
            this.dbContext = _dbContext;
        }

        public PeopleContext Init()
        {
            return dbContext;
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
            {
                dbContext.Dispose();
            }
        }
    }
}