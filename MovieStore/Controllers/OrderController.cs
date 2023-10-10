using MovieStore.Helpers;
using MovieStore.Models;
using MovieStore.Models.ViewModels;
using MovieStore.Services;
using Microsoft.AspNetCore.Mvc;

namespace MovieStore.Controllers
{
    public class OrderController : Controller
    {

        private readonly IOrderService _orderService;
        private readonly ICustomerService _customerService;

        //public OrderController()
        //{

        //}
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

            //var cart = new CartVM();

            //CartMovieVM newCartMovie = new CartMovieVM();
            //newCartMovie.Movie = new Movie() { Title = "First title", Price = 100 };
            //newCartMovie.NoOfCopies = 2;
            //newCartMovie.SubTotal = 200;


            //CartMovieVM newCartMovie2 = new CartMovieVM();
            //newCartMovie2.Movie = new Movie() { Title = "Second title", Price = 200 };
            //newCartMovie2.NoOfCopies = 3;
            //newCartMovie2.SubTotal = 600;

            //cart.CartMovies.Add(newCartMovie);
            //cart.CartMovies.Add(newCartMovie2);

            //cart.Total = 800;

            return View(queryResult);
        }

        public IActionResult ConfirmOrder(string email)
        {
            ConfirmVM confirmVM = new ConfirmVM();

            confirmVM.Customer = _customerService.GetCustomer(email);

            var movieIdsList = HttpContext.Session.Get<List<int>>("movieIdlist");

            confirmVM.Cart = _orderService.GetCartVM(movieIdsList);

            TempData["email"] = email;

            return View(confirmVM);
        }


        public IActionResult CreateOrder()
        {
            var email = (string)TempData["email"];

            var movieIdsList = HttpContext.Session.Get<List<int>>("movieIdlist");

            var cart = _orderService.GetCartVM(movieIdsList);

            _orderService.AddOrder(email, cart.CartMovies);

            return RedirectToAction("ThankYou", "Customer");
        }



    }
}
