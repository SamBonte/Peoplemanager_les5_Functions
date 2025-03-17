using Microsoft.EntityFrameworkCore;
using PeopleManager.Model;
using PeopleManager.Repository;

namespace PeopleManager.Services
{
    public class FunctionService
    {
        private readonly PeopleManagerDbContext _dbContext;

        public FunctionService(PeopleManagerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        //Find
        public async Task<IList<Function>> Find()
        {
            return await _dbContext.Functions
                .ToListAsync();
        }

        //Get(id)
        public async Task<Function?> Get(int id)
        {
            return await _dbContext.Functions.FirstOrDefaultAsync(p => p.Id == id);
        }

        //Create
        public async Task<Function> Create(Function person)
        {
            _dbContext.Functions.Add(person);

            await _dbContext.SaveChangesAsync();

            return person;
        }

        //Update
        public async Task<Function?> Update(int id, Function function)
        {
            var dbFunction = await _dbContext.Functions.FirstOrDefaultAsync(p => p.Id == id);
            if (dbFunction is null)
            {
                return null;
            }

            dbFunction.Name = function.Name;

            await _dbContext.SaveChangesAsync();
            
            return dbFunction;
        }

        //Delete
        public async Task Delete(int id)
        {
            var person = new Function()
            {
                Id = id,
                Name = string.Empty
            };
            _dbContext.Functions.Attach(person);

            _dbContext.Functions.Remove(person);
            await _dbContext.SaveChangesAsync();
        }
    }
}
