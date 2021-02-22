using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonRegister.Core.Domain.Models;
using PersonRegister.Infrastructure.Database.Configurations.DataSeed;

namespace PersonRegister.Infrastructure.Database.Configurations
{
    internal class CityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(30).IsRequired();

            builder.HasData(CitySeed.Tbilisi, CitySeed.Batumi, CitySeed.Kutaisi, CitySeed.Mtsketa);

        }
    }
}
