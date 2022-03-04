using Microsoft.EntityFrameworkCore;
using PersonDirectory.Core.Domain.Aggregates.CityAggregate;
using PersonDirectory.Core.Domain.Aggregates.PersonAggregate;
using PersonDirectory.Infrastructure.Persistence.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonDirectory.Infrastructure.Persistence
{
    public class DataContext:DbContext
    {
        public DbSet<Person> People { get; set; }
        public DbSet<PersonRelation> PersonRelations { get; set; }
        public DbSet<PhoneNumber> PhoneNumbers { get; set; }
        public DbSet<City> Cities { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {


        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new PersonTypeConfiguration());
            modelBuilder.ApplyConfiguration(new PhoneNumberTypeConfiguration());
            modelBuilder.ApplyConfiguration(new PersonRelationTypeConfiguration());
        }

    }
}
