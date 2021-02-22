using Microsoft.EntityFrameworkCore;
using PersonRegister.Core.Application.Interfaces.Repositories;
using PersonRegister.Core.Application.RequestsParameter.Filtering;
using PersonRegister.Core.Application.RequestsParameter.Paging;
using PersonRegister.Core.Domain.Enums;
using PersonRegister.Core.Domain.Models;
using PersonRegister.Infrastructure.Database.Extensions;
using System.Collections.Generic;
using System.Linq;

namespace PersonRegister.Infrastructure.Database.Implementations
{
    internal class PersonRepository : Repository<Person>, IPersonRepository
    {
        public PersonRepository(PersonRegister_DbContext context) : base(context) { }

        public void AddRelatedPerson(int personId, int relatedPersonId, PersonRelationType relationType)
        {
            var personRelation = new PersonRelation { PersonId = personId, RelatedPersonId = relatedPersonId, RelationType = relationType };
            context.PersonRelations.Add(personRelation);
            context.SaveChanges();
        }


        public void AddRelatedPerson(int personId, Person relatedPerson, PersonRelationType relationType)
        {
            var personRelation = new PersonRelation { PersonId = personId, RelatedPerson = relatedPerson, RelationType = relationType };
            context.PersonRelations.Add(personRelation);
            context.SaveChanges();
        }

        public void DeleteRelatedPerson(int personId, int relatedPersonId)
        {
            var personRelation = context.PersonRelations.FirstOrDefault(x => x.PersonId == personId && x.RelatedPersonId == relatedPersonId);
            if (personRelation != null)
            {
                context.PersonRelations.Remove(personRelation);
                context.SaveChanges();
            }
        }

        public override Person GetById(int id)
        {
            var person = context.People
                .Include(x => x.City)
                .Include(x => x.Phones)
                .Include(x => x.RelatedPeople)
                    .ThenInclude(x => x.RelatedPerson)
                        .ThenInclude(x => x.Phones)
                .FirstOrDefault(x => x.Id == id);

            return person;
        }


        public IEnumerable<Person> GetAll(PageRequest pageRequest, out PageResponse pageResponse, PeopleFilter peopleFilter = null)
        {

            var persons = context.People
             .Include(x => x.City)
             .Include(x => x.Phones)
             .Include(x => x.RelatedPeople)
                 .ThenInclude(x => x.RelatedPerson)
                     .ThenInclude(x => x.Phones)
             .ApplyFilterParameters(peopleFilter)
             .TakePage(pageRequest, out pageResponse)
             .ToList();

            return persons;

        }

        public bool IsValidPn(int personId, string pn)
        {
            return !context.People.Any(x => x.Pn == pn && x.Id != personId);
        }
    }
}
