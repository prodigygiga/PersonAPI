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
    public class PhoneNumberTypeConfiguration : IEntityTypeConfiguration<PhoneNumber>
    {
        public void Configure(EntityTypeBuilder<PhoneNumber> builder)
        {
            builder.ToTable("PhoneNumbers", "Person");
            builder.HasQueryFilter(x => x.DeleteDate == null);
            builder
                .Property(x => x.Number)
                .HasMaxLength(50)
                .IsRequired();
            builder
                .OwnsOne(x => x.PhoneNumberType);
            builder
                .Property(x => x.PersonId)
                .IsRequired();
        }
    }
}
