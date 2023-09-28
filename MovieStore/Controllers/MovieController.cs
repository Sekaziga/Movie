using MovieStore.Services;
using Microsoft.AspNetCore.Mvc;
using MovieStore.Models;
using MovieStore.Models.ViewModels;

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
        //public IActionResult Edit()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public IActionResult Edit(Movie newMovie)
        //{
        //    _movieService.UpdateMovie(newMovie);
        //    return RedirectToAction("Index");
        //}
        //public IActionResult Delete(Movie newMovie)
        //{
        //    _movieService.DeleteMovie(newMovie);
        //    return RedirectToAction("Index");
        //}
        //public IActionResult Detail(Movie newMovie)
        //{
        //    _movieService.DetailMovie(newMovie);
        //    return View();
        //}
        //public IActionResult Update(Movie newMovie)
        //{
        //    _movieService.UpdateMovie(newMovie);
        //    return View();
        //}
    }

}
