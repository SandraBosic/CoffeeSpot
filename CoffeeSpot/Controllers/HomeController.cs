using CoffeeSpot.Models;
using CoffeeSpot.Repositories.Interfaces;
using System.Web.Mvc;

namespace CoffeeSpot.Controllers
{
    public class HomeController : Controller
    {
        ICoffeeSpotRepository coffeeRepository;

        public HomeController(ICoffeeSpotRepository coffeeRepository)
        {
            this.coffeeRepository = coffeeRepository;
        }

        public ActionResult Index()
        {
            var coffeeSpots = coffeeRepository.GetAllCofeeSpots();

            return View(coffeeSpots);
        }

        public ActionResult CreateCoffeeSpot(CoffeeSpotModel model)
        {
            coffeeRepository.SaveCoffeeSpot(model);

            return RedirectToAction("Index");
        }

        public ActionResult ClearForm()
        {
            return PartialView("_AddCoffeeSpot", new CoffeeSpotModel());
        }

    }
}