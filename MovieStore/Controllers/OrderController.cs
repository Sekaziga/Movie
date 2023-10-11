

﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieStore.Helpers;
using MovieStore.Models;
using MovieStore.Models.ViewModels;

using MovieStore.Services;

namespace MovieStore.Controllers
{
    public class OrderController : Controller
    {
  

        private readonly IOrderService _orderService;
        private readonly ICustomerService _customerService;

       public OrderController(IOrderService orderService, ICustomerService customerService)
        {
            _orderService = orderService;
            _customerService = customerService;

        }

        public IActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult AddToCart(string id)
        { 

            if (HttpContext.Session.Get<List<int>>("movieIdlist") == default)

            {
                HttpContext.Session.Set<List<int>>("movieIdlist", new List<int>());
            }
            var movieIdsList = HttpContext.Session.Get<List<int>>("movieIdlist");
            movieIdsList.Add(Convert.ToInt32(id));

            HttpContext.Session.Set<List<int>>("movieIdlist", movieIdsList);

            return Json(movieIdsList.Count);
        }

      

        public IActionResult ShoppingCart()
        {
            var movieIdsList = HttpContext.Session.Get<List<int>>("movieIdlist");

            var queryResult = _orderService.GetCartVM(movieIdsList);


            return View(queryResult);
        }

        public IActionResult ConfirmOrder(string email)
        {
            ConfirmVM confirmVM = new ConfirmVM();

            confirmVM.Customer = _customerService.GetCustomer(email);

            var movieIdsList = HttpContext.Session.Get<List<int>>("movieIdlist");

            confirmVM.Cart = _orderService.GetCartVM(movieIdsList);

            TempData["email"] = email;
            TempData["createorder"] = null;



            return View(confirmVM);
        }


        public IActionResult CreateOrder()
        {
            var email = (string)TempData["email"];

            var movieIdsList = HttpContext.Session.Get<List<int>>("movieIdlist");

            var cart = _orderService.GetCartVM(movieIdsList);

            _orderService.AddOrder(email, cart.CartMovies);

            HttpContext.Session.Remove("movieIdlist");

            return RedirectToAction("ThankYou", "Customer");
        }



    }
}
