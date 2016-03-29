﻿using Microsoft.AspNet.Mvc;
using OdeToFood.Entities;
using OdeToFood.Services;
using OdeToFood.ViewModels;

namespace OdeToFood.Controllers
{
    public class HomeController : Controller
    {
        private IRestaurantData _restaurantData;
        private IGreeter _greeter;

        public HomeController(
            IRestaurantData restaurantData,
            IGreeter greeter)
        {
            _restaurantData = restaurantData;
            _greeter = greeter;
        }

        public ViewResult Index()
        {
            var model = new HomePageViewModel
            {
                Restaurants = _restaurantData.GetAll(),
                CurrentGreeting = _greeter.GetGreeting()
            };

            return View(model);
        }

        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(RestaurantEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var restaurant = new Restaurant()
                {
                    Name = model.Name,
                    Cuisine = model.Cuisine
                };

                _restaurantData.Add(restaurant);

                return RedirectToAction("Details", new { id = restaurant.Id });
            }
            return View();

        }



        public IActionResult Details(int id)
        {
            var model = _restaurantData.Get(id);
            if (model == null)
            {
                return RedirectToAction("Index");
            }
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
