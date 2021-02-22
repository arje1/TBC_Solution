using System.Collections.Generic;

namespace PersonRegister.Core.Domain.Models
{
    public class City
    {
        public City()
        {
            People = new HashSet<Person>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Person> People { get; set; }
    }
}
