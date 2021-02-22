using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonRegister.Core.Domain.Models;

namespace PersonRegister.Infrastructure.Database.Configurations
{
    internal class PhoneConfiguration : IEntityTypeConfiguration<Phone>
    {
        public void Configure(EntityTypeBuilder<Phone> builder)
        {
            builder.Property(x => x.Number).HasMaxLength(50).IsRequired();
            builder.Property(x => x.NumberType).IsRequired();
            builder.Property(x => x.PersonId).IsRequired();
        }
    }
}
