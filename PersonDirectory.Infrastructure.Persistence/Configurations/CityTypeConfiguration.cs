using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonDirectory.Core.Domain.Aggregates.CityAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonDirectory.Infrastructure.Persistence.Configurations
{
    public class CityTypeConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.ToTable(nameof(City), "Common");
            builder.HasQueryFilter(x => x.DeleteDate == null);
            builder.Ignore(x => x.DomainEvents);
            builder
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();
        }
    }
}
