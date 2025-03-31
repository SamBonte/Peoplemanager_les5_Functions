
namespace PeopleManager.Dtos.Results
{
    public class FunctionResult
    {
        public int Id { get; set; }
        public required string Name { get; set; }

        public int NumberOfPeople { get; set; }
    }
}
