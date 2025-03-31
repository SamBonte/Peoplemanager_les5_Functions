using Microsoft.AspNetCore.Mvc;
using PeopleManager.Dtos.Requests;
using PeopleManager.Sdk;

namespace PeopleManager.Ui.Mvc.Controllers
{
    public class PeopleController(
        PersonApiService personService,
        FunctionApiService functionService) : Controller
    {
        private readonly PersonApiService _personService = personService;
        private readonly FunctionApiService _functionService = functionService;

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var people = await _personService.Find();
            return View(people);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var functions = await _functionService.Find();
            ViewBag.Functions = functions;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm]PersonRequest request)
        {
            if (!ModelState.IsValid)
            {
                return View(request);
            }

            await _personService.Create(request);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit([FromRoute]int id)
        {
            var person = await _personService.Get(id);
            if (person is null)
            {
                return RedirectToAction("Index");
            }

            var functions = await _functionService.Find();
            ViewBag.Functions = functions;

            var request = new PersonRequest
            {
                FirstName = person.FirstName,
                LastName = person.LastName,
                Email = person.Email,
                FunctionId = person.FunctionId
            };

            return View(request);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([FromRoute]int id, [FromForm]PersonRequest request)
        {
            if (!ModelState.IsValid)
            {
                return View(request);
            }

            await _personService.Update(id, request);

            return RedirectToAction("Index");
        }


        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var person = await _personService.Get(id);
            if (person is null)
            {
                return RedirectToAction("Index");
            }

            return View(person);
        }

        [HttpPost("People/Delete/{id:int?}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _personService.Delete(id);

            return RedirectToAction("Index");
        }
    }
}
