using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
namespace WepApp.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new PeopleContext(
                serviceProvider.GetRequiredService<DbContextOptions<PeopleContext>>()))
            {
                if (context.Peoples.Any())
                {
                    return;
                }

                context.Peoples.AddRange(
                    new People
                    {
                        Name = "Minh Thong",
                        Age = 22
                    },

                     new People
                     {
                         Name = "Minh Thong",
                         Age = 22
                     },

                      new People
                      {
                          Name = "Minh Thong",
                          Age = 22
                      },

                       new People
                       {
                           Name = "Minh Thong",
                           Age = 22
                       }
                    );

                context.SaveChanges();
            }
        }
    }
}
