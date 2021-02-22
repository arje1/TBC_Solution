using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonRegister.Core.Domain.Models;
using PersonRegister.Infrastructure.Database.Configurations.DataSeed;

namespace PersonRegister.Infrastructure.Database.Configurations
{
    internal class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.Property(x => x.FirstName).HasMaxLength(50).IsRequired();
            builder.Property(x => x.LastName).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Pn).HasMaxLength(20).IsRequired();
            builder.Property(x => x.BirthDate).HasColumnType("date").IsRequired();
            builder.Property(x => x.Gender).IsRequired();

            builder.HasIndex(x => x.Pn).IsUnique();

            builder.HasOne(x => x.City).WithMany(c => c.People).HasForeignKey(x => x.CityId);


            builder.HasData
                        (
                            PersonSeed.PetrePetriashvili,
                            PersonSeed.PavlePavliashvili,
                            PersonSeed.NinoNinidze,
                            PersonSeed.MariamMariamidze,
                            PersonSeed.JumberTkabladze
                        );
        }
    }
}
