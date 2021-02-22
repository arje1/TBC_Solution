using PersonRegister.Core.Application.Interfaces;
using PersonRegister.Core.Application.Interfaces.Reports;
using PersonRegister.Core.Application.Interfaces.Repositories;
using PersonRegister.Infrastructure.Database.Implementations;
using PersonRegister.Infrastructure.Database.Implementations.Reports;

namespace PersonRegister.Infrastructure.Database
{
    internal class UnitOfPersonRegister : IUnitOfPersonRegister
    {
        private IPersonRepository personRepository;
        private ICityRepository cityRepository;
        private IPersonReport personReport;

        private PersonRegister_DbContext context;
        public UnitOfPersonRegister(PersonRegister_DbContext context) => this.context = context;

        public IPersonRepository PersonRepository => personRepository ??= new PersonRepository(context);
        public ICityRepository CityRepository => cityRepository ??= new CityRepository(context);
        public IPersonReport PersonReport => personReport ??= new PersonReport(context);
    }
}
