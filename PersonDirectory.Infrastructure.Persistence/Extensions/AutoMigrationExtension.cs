using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PersonDirectory.Core.Domain.Aggregates.CityAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonDirectory.Infrastructure.Persistence.Extensions
{
    public static class AutoMigrationExtension
    {
        public static void PrepareDbPopulation(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<DataContext>());
            }
        }
        public static void SeedData(DataContext context)
        {
            Console.WriteLine("Appling Migrations... ");
            context.Database.Migrate();

            if (!context.Cities.Any())
            {
                context.Cities.AddRange(
                new City(1, "ქუთაისი", DateTime.Now),
                new City(2, "თბილისი", DateTime.Now),
                new City(3, "ბათუმი", DateTime.Now)
                );
                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("Data Already Exists!");
            }
        }
    }
}
