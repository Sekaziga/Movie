using MovieStore.Models;
using MovieStore.Models.ViewModels;
using MovieStore.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace MovieStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMovieService _movieService;
        private readonly IOrderService _orderService;

        public HomeController(ILogger<HomeController> logger,
             IMovieService movieService,
             IOrderService order
             )
        {
            _logger = logger;
            _movieService = movieService;
            _orderService = order;
        }

        public IActionResult Index()
        {
            var movies = _movieService.GetMovies();
            FrontPageVM frontPage = new FrontPageVM();

            frontPage.TopSellerMovies = _orderService.GetMostSoldMovies();

            frontPage.CheapestMovies = movies
                .OrderBy(m => m.Price)
                .Take(5)
                .ToList();

            frontPage.NewestMovies = movies
                .OrderByDescending(m => m.ReleaseYear)
                .Take(5)
                .ToList();

            frontPage.OldestMovies = movies
                .OrderBy(m => m.ReleaseYear)
                .Take(5)
                .ToList();



            return View(frontPage);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
