using PersonRegister.Core.Domain.Models;

namespace PersonRegister.Infrastructure.Database.Configurations.DataSeed
{
    internal static class CitySeed
    {
        internal static readonly City Tbilisi = new City { Id = 1, Name = "Tbilisi" };
        internal static readonly City Batumi = new City { Id = 2, Name = "Batumi" };
        internal static readonly City Kutaisi = new City { Id = 3, Name = "Kutaisi" };
        internal static readonly City Mtsketa = new City { Id = 4, Name = "Mtsketa" };
    }
}
