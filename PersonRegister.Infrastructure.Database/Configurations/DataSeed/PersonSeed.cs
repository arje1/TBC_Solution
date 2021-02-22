using PersonRegister.Core.Domain.Enums;
using PersonRegister.Core.Domain.Models;
using System;

namespace PersonRegister.Infrastructure.Database.Configurations.DataSeed
{
    internal static class PersonSeed
    {
        internal static readonly Person PetrePetriashvili = new Person
        {
            Id = 1,
            FirstName = "Petre",
            LastName = "Petriashvili",
            Pn = "00000000000",
            BirthDate = DateTime.Now.AddYears(-25),
            Gender = Gender.Male,
            CityId = CitySeed.Mtsketa.Id
        };

        internal static readonly Person PavlePavliashvili = new Person
        {
            Id = 2,
            FirstName = "Pavle",
            LastName = "Pavliashvili",
            Pn = "11111111111",
            BirthDate = DateTime.Now.AddYears(-27),
            Gender = Gender.Male,
            CityId = CitySeed.Tbilisi.Id
        };

        internal static readonly Person NinoNinidze = new Person
        {
            Id = 3,
            FirstName = "Nino",
            LastName = "Ninidze",
            Pn = "22222222222",
            BirthDate = DateTime.Now.AddYears(-29),
            Gender = Gender.Female,
            CityId = CitySeed.Tbilisi.Id
        };

        internal static readonly Person MariamMariamidze = new Person
        {
            Id = 4,
            FirstName = "Mariam",
            LastName = "Mariamidze",
            Pn = "33333333333",
            BirthDate = DateTime.Now.AddYears(-19),
            Gender = Gender.Female,
            CityId = CitySeed.Kutaisi.Id
        };

        internal static readonly Person JumberTkabladze = new Person
        {
            Id = 5,
            FirstName = "Jumber",
            LastName = "Tkabladze",
            Pn = "44444444444",
            BirthDate = DateTime.Now.AddYears(-19),
            Gender = Gender.Female,
            CityId = CitySeed.Kutaisi.Id
        };

    }
}
