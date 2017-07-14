using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace pgSQL.Models
{
    public static class DBInitialize
    {
        public static void EnsureCreated(IServiceProvider serviceProvider)
        {
            var context = new AppDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>()
            );
            context.Database.EnsureCreated();
        }
    }
}