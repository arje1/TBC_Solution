using PersonRegister.Core.Application.RequestsParameter.Filtering;
using PersonRegister.Core.Application.RequestsParameter.Paging;
using PersonRegister.Core.Domain.Enums;
using PersonRegister.Core.Domain.Models;
using System.Collections.Generic;

namespace PersonRegister.Core.Application.Interfaces.Repositories
{
    public interface IPersonRepository : IRepository<Person>
    {
        public void AddRelatedPerson(int personId, int relatedPersonId, PersonRelationType relationType);
        public void AddRelatedPerson(int personId, Person relatedPerson, PersonRelationType relationType);
        public void DeleteRelatedPerson(int personId, int relatedPersonId);
        IEnumerable<Person> GetAll(PageRequest pageRequest, out PageResponse pageResponse, PeopleFilter peopleFilter = null);
        public bool IsValidPn(int personId, string pn);


    }
}
