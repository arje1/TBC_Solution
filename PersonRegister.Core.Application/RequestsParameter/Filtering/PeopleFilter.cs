using PersonRegister.Core.Domain.Enums;
using System;

namespace PersonRegister.Core.Application.RequestsParameter.Filtering
{
    public class PeopleFilter
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Pn { get; set; }
        public DateTime? BirthDate { get; set; } = null;
        public int CityId { get; set; }
        public string City { get; set; }
        public bool? HasPhoto { get; set; } = null;
        public string RelatedPersonFirstName { get; set; }
        public string RelatedPersonLastName { get; set; }
        public string RelatedPersonPn { get; set; }

    }
}
