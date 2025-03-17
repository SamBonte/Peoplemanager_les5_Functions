using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PeopleManager.Model;
using PeopleManager.Services;

namespace PeopleManager.RestApi.Controllers
{
    [Route("api/people")]
    [ApiController]
    public class PeopleController(PersonService personService) : ControllerBase
    {
        private readonly PersonService _personService = personService;

        [HttpGet]
        public async Task<IActionResult> Find()
        {
            var people = await _personService.Find();
            return Ok(people);
        }

        [HttpGet("{id:int}", Name="GetPersonRoute")]
        public async Task<IActionResult> Get([FromRoute]int id)
        {
            var person = await _personService.Get(id);
            return Ok(person);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Person person)
        {
            var createdPerson = await _personService.Create(person);
            return CreatedAtRoute("GetPersonRoute", new { id = createdPerson.Id }, createdPerson);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] Person person)
        {
            var updatedPerson = await _personService.Update(id, person);
            return Ok(updatedPerson);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await _personService.Delete(id);
            return Ok();
        }
    }
}
