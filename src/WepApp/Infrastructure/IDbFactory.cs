using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WepApp.Models;

namespace WepApp.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        PeopleContext Init();
    }
}
