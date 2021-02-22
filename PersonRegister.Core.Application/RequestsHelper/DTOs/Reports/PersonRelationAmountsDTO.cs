using PersonRegister.Core.Domain.Enums;

namespace PersonRegister.Core.Application.RequestsHelper.DTOs.Reports
{
    public class PersonRelationAmountsDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Pn { get; set; }
        public PersonRelationType RelationType { get; set; }
        public int RelatedPeopleAmount { get; set; }


    }
}
