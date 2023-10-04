using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieStore.Helpers;
using MovieStore.Models;
using MovieStore.Models.ViewModels;

namespace MovieStore.Controllers
{
    public class OrderController : Controller
    {
        public OrderController ()
        {
            
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddTocart(string id)
        {
            if (HttpContext.Session.Get<List<int>>("movieIdlist")== default)
            {
                HttpContext.Session.Set<List<int>>("movieIdlist", new List< int > ());
            }
            var movieIdList = HttpContext.Session.Get<List<int>>("movieIdlist");
            movieIdList.Add(Convert.ToInt32(id));

            HttpContext.Session.Set<List<int>>("movieIdlist", movieIdList);


            return Json(movieIdList.Count);
        }
        public IActionResult ShoppingCart() 
        {
            var cart = new CartVM();
            CartMovieVM newCartMovie = new CartMovieVM();
            newCartMovie.Movie = new Movie()/* { Tittle = "First tittle" }*/;
            newCartMovie.NoOfCopies = 2;
            newCartMovie.SubTotal = 200;
            
            

            CartMovieVM newCartMovie2 = new CartMovieVM();
            newCartMovie2.Movie = new Movie() /*{ Tittle = "Second tittle" }*/;
            newCartMovie2.NoOfCopies = 2;
            newCartMovie2.SubTotal = 200;

            cart.Movie.Add(newCartMovie);
            cart.Movie.Add(newCartMovie2);

            cart.Total = 800;

            return View();
        }

    }
}
