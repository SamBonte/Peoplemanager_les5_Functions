using Microsoft.AspNetCore.Mvc;
using PeopleManager.Dtos.Requests;
using PeopleManager.Services;

namespace PeopleManager.RestApi.Controllers
{
    [Route("api/functions")]
    [ApiController]
    public class FunctionsController(FunctionService functionService) : ControllerBase
    {
        private readonly FunctionService _functionService = functionService;

        [HttpGet]
        public async Task<IActionResult> Find()
        {
            var functions = await _functionService.Find();
            return Ok(functions);
        }

        [HttpGet("{id:int}", Name="GetFunctionRoute")]
        public async Task<IActionResult> Get([FromRoute]int id)
        {
            var function = await _functionService.Get(id);
            return Ok(function);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] FunctionRequest request)
        {
            var createdFunction = await _functionService.Create(request);
            if (createdFunction is null)
            {
                return Ok(createdFunction);
            }
            return CreatedAtRoute("GetFunctionRoute", new { id = createdFunction.Id }, createdFunction);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] FunctionRequest request)
        {
            var updatedFunction = await _functionService.Update(id, request);
            return Ok(updatedFunction);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await _functionService.Delete(id);
            return Ok();
        }
    }
}
