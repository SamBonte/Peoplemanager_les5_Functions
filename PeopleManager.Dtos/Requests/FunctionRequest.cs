using System.ComponentModel.DataAnnotations;


namespace PeopleManager.Dtos.Requests
{
    public class FunctionRequest
    {
        [Required]
        public required string Name { get; set; }
    }
}
