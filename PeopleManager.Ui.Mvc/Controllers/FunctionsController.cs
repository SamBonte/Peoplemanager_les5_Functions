using Microsoft.AspNetCore.Mvc;
using PeopleManager.Dtos.Requests;
using PeopleManager.Sdk;

namespace PeopleManager.Ui.Mvc.Controllers
{
    public class FunctionsController(FunctionApiService functionService) : Controller
    {
        private readonly FunctionApiService _functionService = functionService;

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var functions = await _functionService.Find();
            return View(functions);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm]FunctionRequest request)
        {
            if (!ModelState.IsValid)
            {
                return View(request);
            }

            await _functionService.Create(request);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit([FromRoute]int id)
        {
            var function = await _functionService.Get(id);
            if (function is null)
            {
                return RedirectToAction("Index");
            }

            var result = new FunctionRequest
            {
                Name = function.Name,
            };

            return View(result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([FromRoute]int id, [FromForm]FunctionRequest request)
        {
            if (!ModelState.IsValid)
            {
                return View(request);
            }

            await _functionService.Update(id, request);

            return RedirectToAction("Index");
        }
        
        [HttpPost("Functions/Delete/{id:int?}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _functionService.Delete(id);

            return RedirectToAction("Index");
        }
    }
}
