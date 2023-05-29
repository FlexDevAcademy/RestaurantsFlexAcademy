using Microsoft.AspNetCore.Mvc;
using RestaurantsFlexDevAcademy.Models;
using RestaurantsFlexDevAcademy.Services;

namespace RestaurantsFlexDevAcademy.Controllers
{
    public class RestaurantsController : Controller
    {
        private readonly IRestaurantService _db;

        public RestaurantsController(IRestaurantService db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var model = await _db.GetAll();

            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Restaurant restaurant)
        {
            if(ModelState.IsValid)
            {
                await _db.Add(restaurant);

                return RedirectToAction("Details", new { id = restaurant.Id });
            }

            return View();
        }

        [HttpGet]
        public async Task<ActionResult> Details(int id)
        {
            var model = await _db.Get(id);

            if(model == null)
            {
                return View("NotFound");
            }

            return View(model);

        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var model = await _db.Get(id);

            if(model == null)
            {
                return View("NotFound");
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, IFormCollection form)
        {
            await _db.Delete(id);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var model = await _db.Get(id);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Restaurant restaurant)
        {
            if(ModelState.IsValid)
            {
                await _db.Update(restaurant);

                return RedirectToAction("Details", new { id = restaurant.Id });
            }

            return View(restaurant);
        }
    }
}
