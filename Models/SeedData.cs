using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace pgSQL.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using(var context = new AppDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>() ))
            {
                if (context.Users.Any())
                {
                    return;    // DB has been seeded
                }

                context.Users.AddRange(
                    new User
                    {
                        FirstName = "Alan",
                        LastName = "Jui",
                        BlogSiteUrl = "https://www.facebook.com/AlanJui",
                        Birthday = DateTime.Parse("1960-9-25")  
                    },

                    new User
                    {
                        FirstName = "Stacy",
                        LastName = "Wu",
                        BlogSiteUrl = null,
                        Birthday = DateTime.Parse("1967-8-18")  
                    },

                    new User
                    {
                        FirstName = "Amos",
                        LastName = "Jui",
                        BlogSiteUrl = "https://www.facebook.com/AmosJui",
                        Birthday = DateTime.Parse("2003-6-4")  
                    }
                );
                context.SaveChanges();
            }
        }
    }
}