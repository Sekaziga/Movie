using MovieStore.Services;
using Microsoft.AspNetCore.Mvc;
using MovieStore.Models;

namespace MovieStore.Controllers
{
    public class MovieController : Controller
    {

        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        public IActionResult Index()
        {
            var movieList = _movieService.GetMovies();
            return View(movieList);

        }


        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Movie newMovie)
        {
            _movieService.CreateMovie(newMovie);
            return RedirectToAction("Index");
        }



    }
}
