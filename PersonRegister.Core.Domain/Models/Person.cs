using PersonRegister.Core.Domain.Enums;
using System;
using System.Collections.Generic;

namespace PersonRegister.Core.Domain.Models
{
    public class Person
    {
        public Person()
        {
            Phones = new HashSet<Phone>();
            RelatedPeople = new HashSet<PersonRelation>();
        }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public string Pn { get; set; }
        public DateTime BirthDate { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }
        public ICollection<Phone> Phones { get; set; }
        public string PhotoPath { get; set; }
        public ICollection<PersonRelation> RelatedPeople { get; set; }
    }
}
