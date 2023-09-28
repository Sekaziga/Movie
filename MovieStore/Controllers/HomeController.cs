using MovieStore.Models;
using MovieStore.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using MovieStore.Models.ViewModels;

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

            FrontPageVM frontPage = new FrontPageVM();
            frontPage.Top5Movies = movieList
                .OrderBy(m => m.Price).Take(5)
                .ToList();

            frontPage.Top5OldestMovies = movieList
                .OrderBy(m => m.ReleaseYear).Take(5)
                .ToList();

            frontPage.Top5CheapestMovies = movieList
                .OrderBy(m => m.Price).Take(5)
                .ToList();

            frontPage.Top5NewestMovies = movieList
                .OrderByDescending(m => m.ReleaseYear).Take(5)
                .ToList();

            //frontPage.Top5CheapestMovies = movieList;
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
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Movie newMovie)
        {
            _movieService.CreateMovie(newMovie);
            return View();
        }
        //public IActionResult Update(Movie newMovie)
        //{
        //    _movieService.UpdateMovie(newMovie);
        //    return View();
        //}
    }
}
