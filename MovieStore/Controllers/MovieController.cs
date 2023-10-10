﻿using MovieStore.Models.ViewModels;
using MovieStore.Models;
using MovieStore.Services;
using Microsoft.AspNetCore.Mvc;


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

        public IActionResult Details(int id)
        {
            return View(_movieService.GetMovie(id));
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
