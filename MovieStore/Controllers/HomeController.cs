using MovieStore.Models;
using MovieStore.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;


namespace MovieStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMovieService _movieService;

        public HomeController(ILogger<HomeController> logger,
              IMovieService movieService
              )
        {
            _logger = logger;
            _movieService = movieService;
        }

        public IActionResult Index()
        {
            var movieList = _movieService.GetMovies();
            return View(movieList);
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