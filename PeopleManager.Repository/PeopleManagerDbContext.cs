using Microsoft.EntityFrameworkCore;
using PeopleManager.Model;

namespace PeopleManager.Repository
{
    public class PeopleManagerDbContext(DbContextOptions<PeopleManagerDbContext> options) : DbContext(options)
    {
        public DbSet<Function> Functions => Set<Function>();
        public DbSet<Person> People => Set<Person>();
        
            
        public void Seed()
        {
            var createdDate = DateTime.UtcNow;
            var function = new Function { Name = "Manager", CreatedDate = createdDate};
            Functions.AddRange(
                function,
                new Function {Name = "Employee", CreatedDate = createdDate}
                );
            
            var people = new List<Person>
            {
                new Person { FirstName = "John", LastName = "Doe", Email = "john.doe@example.com", Function = function, CreatedDate = createdDate},
                new Person { FirstName = "Jane", LastName = "Smith", Email = null },  // No email
                new Person { FirstName = "Alice", LastName = "Johnson", Email = "alice.johnson@example.com" , CreatedDate = createdDate},
                new Person { FirstName = "Bob", LastName = "Williams", Email = null, Function = function , CreatedDate = createdDate}, // No email
                new Person { FirstName = "Charlie", LastName = "Brown", Email = "charlie.brown@example.com" , CreatedDate = createdDate},
                new Person { FirstName = "David", LastName = "Miller", Email = null }, // No email
                new Person { FirstName = "Emily", LastName = "Davis", Email = "emily.davis@example.com" , CreatedDate = createdDate},
                new Person { FirstName = "Frank", LastName = "Garcia", Email = "frank.garcia@example.com" , CreatedDate = createdDate},
                new Person { FirstName = "Grace", LastName = "Martinez", Email = null , CreatedDate = createdDate}, // No email
                new Person { FirstName = "Henry", LastName = "Rodriguez", Email = "henry.rodriguez@example.com", Function = function, CreatedDate = createdDate}
            };

            People.AddRange(people);

            SaveChanges();
        }
    }
}
