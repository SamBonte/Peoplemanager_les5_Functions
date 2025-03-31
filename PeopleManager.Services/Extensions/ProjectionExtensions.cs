using PeopleManager.Dtos.Results;
using PeopleManager.Model;

namespace PeopleManager.Services.Extensions
{
    public static class ProjectionExtensions
    {
        public static IQueryable<PersonResult> ProjectToResult(this IQueryable<Person> query)
        {
            return query.Select(p => new PersonResult
            {
                Id = p.Id,
                FirstName = p.FirstName,
                LastName = p.LastName,
                Email = p.Email,
                FunctionId = p.FunctionId,
                FunctionName = p.Function != null ? p.Function.Name : null
            });
        }
    }
}
