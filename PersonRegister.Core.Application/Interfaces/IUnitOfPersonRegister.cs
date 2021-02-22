using PersonRegister.Core.Application.Interfaces.Reports;
using PersonRegister.Core.Application.Interfaces.Repositories;

namespace PersonRegister.Core.Application.Interfaces
{
    public interface IUnitOfPersonRegister
    {
        public IPersonRepository PersonRepository { get; }
        public IPersonReport PersonReport { get; }
        public ICityRepository CityRepository { get; }
    }
}
