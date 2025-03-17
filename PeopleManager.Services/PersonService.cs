using Microsoft.EntityFrameworkCore;
using PeopleManager.Model;
using PeopleManager.Repository;

namespace PeopleManager.Services
{
    public class PersonService
    {
        private readonly PeopleManagerDbContext _dbContext;

        public PersonService(PeopleManagerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        //Find
        public async Task<IList<Person>> Find()
        {
            var people = await _dbContext.People
                .Include(p => p.Function)
                .ToListAsync();

            return people;
        }

        //Get(id)
        public async Task<Person?> Get(int id)
        {
            return await _dbContext.People.FirstOrDefaultAsync(p => p.Id == id);
        }

        //Create
        public async Task<Person> Create(Person person)
        {
            _dbContext.People.Add(person);

            await _dbContext.SaveChangesAsync();

            return person;
        }

        //Update
        public async Task<Person?> Update(int id, Person person)
        {
            var dbPerson = await _dbContext.People.FirstOrDefaultAsync(p => p.Id == id);
            if (dbPerson is null)
            {
                return null;
            }

            dbPerson.FirstName = person.FirstName;
            dbPerson.LastName = person.LastName;
            dbPerson.Email = person.Email;

            await _dbContext.SaveChangesAsync();
            
            return dbPerson;
        }

        //Delete
        public async Task Delete(int id)
        {
            var person = new Person()
            {
                Id = id,
                FirstName = string.Empty,
                LastName = string.Empty
            };
            _dbContext.People.Attach(person);

            _dbContext.People.Remove(person);
            await _dbContext.SaveChangesAsync();
        }
    }
}
