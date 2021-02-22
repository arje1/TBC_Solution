using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonRegister.Core.Domain.Models;

namespace PersonRegister.Infrastructure.Database.Configurations
{
    internal class PersonRelationConfiguration : IEntityTypeConfiguration<PersonRelation>
    {
        public void Configure(EntityTypeBuilder<PersonRelation> builder)
        {
            builder.Property(x => x.PersonId).IsRequired();
            builder.Property(x => x.RelatedPersonId).IsRequired();
            builder.HasOne(x => x.Person).WithMany(x => x.RelatedPeople).HasForeignKey(x => x.PersonId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.RelatedPerson).WithMany().HasForeignKey(x => x.RelatedPersonId).OnDelete(DeleteBehavior.NoAction);


        }
    }
}
