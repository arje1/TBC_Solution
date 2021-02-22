using PersonRegister.Core.Domain.Models;
using Microsoft.EntityFrameworkCore;
using PersonRegister.Infrastructure.Database.Configurations;

namespace PersonRegister.Infrastructure.Database
{
    internal class PersonRegister_DbContext : DbContext
    {
        public PersonRegister_DbContext(DbContextOptions<PersonRegister_DbContext> options) : base(options) { }
        public DbSet<Person> People { get; private set; }
        public DbSet<City> Cities { get; private set; }
        public DbSet<PersonRelation> PersonRelations { get; private set; }
        public DbSet<Phone> Phones { get; private set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CityConfiguration());
            modelBuilder.ApplyConfiguration(new PersonConfiguration());
            modelBuilder.ApplyConfiguration(new PhoneConfiguration());
            modelBuilder.ApplyConfiguration(new PersonRelationConfiguration());
        }
    }
}
