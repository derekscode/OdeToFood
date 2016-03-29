using Microsoft.AspNet.Mvc;
using OdeToFood.Entities;
using OdeToFood.Services;

namespace OdeToFood.Controllers
{
    public class HomeController : Controller
    {
        private IRestaurantData _restaurantData;

        public HomeController(IRestaurantData restaurantData)
        {
            _restaurantData = restaurantData;
        }

        public ViewResult Index()
        {
            var model = _restaurantData.GetAll();

            return View(model);
        }



        //example
        public ObjectResult Example()
        {
            var model = new Restaurant
            {
                Id = 1,
                Name = "Sabatino's"
            };

            return new ObjectResult(model);
        }
    }
}
