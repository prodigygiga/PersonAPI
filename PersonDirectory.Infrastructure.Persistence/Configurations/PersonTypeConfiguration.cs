using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonDirectory.Core.Domain.Aggregates.PersonAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonDirectory.Infrastructure.Persistence.Configurations
{
    public class PersonTypeConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable("People", "Person");
            builder.HasQueryFilter(x => x.DeleteDate == null);
            builder.Ignore(x => x.DomainEvents);
            builder.Property(x => x.FirstName).HasMaxLength(50).IsRequired();
            builder.Property(x => x.LastName).HasMaxLength(50).IsRequired();
            builder.Property(x => x.PrivateNumber).HasMaxLength(20).IsRequired();
            builder.Property(x => x.BirthDate).HasColumnType("date").IsRequired();
            //builder.Property(x => x.Gender).IsRequired();
            builder.Property(x => x.CityId).IsRequired();
            builder.HasIndex(x => x.PrivateNumber).IsUnique();
            builder.OwnsOne(x => x.Gender);

        }
    }
}
