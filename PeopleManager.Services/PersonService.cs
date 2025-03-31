using Microsoft.EntityFrameworkCore;
using PeopleManager.Dtos.Requests;
using PeopleManager.Dtos.Results;
using PeopleManager.Model;
using PeopleManager.Repository;
using PeopleManager.Services.Extensions;

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
        public async Task<IList<PersonResult>> Find()
        {
            var people = await _dbContext.People
                .Include(p => p.Function)
                .ProjectToResult()
                .ToListAsync();

            return people;
        }

        //Get(id)
        public async Task<PersonResult?> Get(int id)
        {
            return await _dbContext.People
                .Include(p => p.Function)
                .ProjectToResult()
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        //Create
        public async Task<PersonResult?> Create(PersonRequest request)
        {
            var person = new Person
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                FunctionId = request.FunctionId,
                CreatedDate = DateTime.UtcNow
            };

            _dbContext.People.Add(person);

            await _dbContext.SaveChangesAsync();

            return await Get(person.Id);
        }

        //Update
        public async Task<PersonResult?> Update(int id, PersonRequest request)
        {
            var person = await _dbContext.People.FirstOrDefaultAsync(p => p.Id == id);
            if (person is null)
            {
                return null;
            }

            person.FirstName = request.FirstName;
            person.LastName = request.LastName;
            person.Email = request.Email;
            person.FunctionId = request.FunctionId; //toegevoegd

            await _dbContext.SaveChangesAsync();
            
            return await Get(id);
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
