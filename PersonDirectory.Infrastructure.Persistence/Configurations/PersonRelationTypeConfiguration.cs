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
    public class PersonRelationTypeConfiguration : IEntityTypeConfiguration<PersonRelation>
    {
        public void Configure(EntityTypeBuilder<PersonRelation> builder)
        {
            builder.ToTable(nameof(PersonRelation), "Person");
            builder.Ignore(x => x.DomainEvents);
            builder
                .Property(x => x.PersonId)
                .IsRequired();
            builder
                .Property(x => x.RelatedPersonId)
                .IsRequired();
            builder
                .HasOne(x => x.Person)
                .WithMany(x => x.Relations)
                .HasForeignKey(x => x.PersonId)
                .OnDelete(DeleteBehavior.NoAction);
            builder
                .HasOne(x => x.RelatedPerson)
                .WithMany()
                .HasForeignKey(x => x.RelatedPersonId)
                .OnDelete(DeleteBehavior.NoAction);
            builder
                .OwnsOne(x => x.RelationType);


        }
    }
}
