using System.ComponentModel.DataAnnotations.Schema;

namespace PeopleManager.Model
{
    [Table(nameof(Function))]
    public class Function
    {
        public int Id { get; set; }
        public required string Name { get; set; }

        public DateTime CreatedDate { get; set; }

        public IList<Person> People { get; set; } = new List<Person>();
    }
}
