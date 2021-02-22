using PersonRegister.Core.Application.Interfaces.Repositories;
using PersonRegister.Core.Domain.Models;

namespace PersonRegister.Infrastructure.Database.Implementations
{
    internal class CityRepository : Repository<City>, ICityRepository
    {
        public CityRepository(PersonRegister_DbContext context) : base(context) { }

    }
}
