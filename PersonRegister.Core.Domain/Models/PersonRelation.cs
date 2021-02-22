using PersonRegister.Core.Domain.Enums;

namespace PersonRegister.Core.Domain.Models
{
    public class PersonRelation
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public Person Person { get; set; }
        public int RelatedPersonId { get; set; }
        public Person RelatedPerson { get; set; }
        public PersonRelationType RelationType { get; set; }

    }
}
