using Microsoft.EntityFrameworkCore;
using PeopleManager.Dtos.Requests;
using PeopleManager.Dtos.Results;
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
        public async Task<IList<FunctionResult>> Find()
        {
            return await _dbContext.Functions
                .Select(f => new FunctionResult
                {
                    Id = f.Id,
                    Name = f.Name,
                    NumberOfPeople = 0

                })
                .ToListAsync();
        }

        //Get(id)
        public async Task<FunctionResult?> Get(int id)
        {
            return await _dbContext.Functions
                .Select(f => new FunctionResult
                {
                    Id = f.Id,
                    Name = f.Name,
                    NumberOfPeople = f.People.Count()
                })
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        //Create
        public async Task<FunctionResult?> Create(FunctionRequest request)
        {
            var function = new Function
            {
                Name = request.Name,
                CreatedDate = DateTime.UtcNow,
                People = new List<Person>()
            };

            _dbContext.Functions.Add(function);

            await _dbContext.SaveChangesAsync();

            return await Get(function.Id);
        }

        //Update
        public async Task<FunctionResult?> Update(int id, FunctionRequest request)
        {
            var dbFunction = await _dbContext.Functions.FirstOrDefaultAsync(p => p.Id == id);
            if (dbFunction is null)
            {
                return null;
            }

            dbFunction.Name = request.Name;

            await _dbContext.SaveChangesAsync();
            
            return await Get(id);
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
