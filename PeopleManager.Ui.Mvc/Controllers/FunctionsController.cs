using Microsoft.AspNetCore.Mvc;
using PeopleManager.Model;
using PeopleManager.Ui.Mvc.Services;

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
        public async Task<IActionResult> Create([FromForm]Function function)
        {
            if (!ModelState.IsValid)
            {
                return View(function);
            }

            await _functionService.Create(function);

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

            return View(function);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([FromRoute]int id, [FromForm]Function function)
        {
            if (!ModelState.IsValid)
            {
                return View(function);
            }

            await _functionService.Update(id, function);

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
