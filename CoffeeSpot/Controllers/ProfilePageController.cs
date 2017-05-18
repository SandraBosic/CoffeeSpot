using CoffeeSpot.Repositories.Interfaces;
using System.Web.Mvc;

namespace CoffeeSpot.Controllers
{
    public class ProfilePageController : Controller
    {
        ICoffeeSpotRepository coffeeRepository;

        public ProfilePageController(ICoffeeSpotRepository coffeeRepository)
        {
            this.coffeeRepository = coffeeRepository;
        }
        
        public ActionResult Index(int id)
        {
            var coffeeSpotDetails = coffeeRepository.GetCoffeeSpot(id);

            int sumOfGrades = 0;
            foreach (var feedback in coffeeSpotDetails.Feedbacks)
            { 
                sumOfGrades += feedback.Grade;
            }

            if (coffeeSpotDetails.Feedbacks.Count > 0)
                ViewBag.AverageGrade = sumOfGrades / coffeeSpotDetails.Feedbacks.Count;
            else
                ViewBag.AverageGrade = 0;

            return View(coffeeSpotDetails);
        }
    }
}