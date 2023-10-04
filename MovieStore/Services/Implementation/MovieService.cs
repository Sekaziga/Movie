using MovieStore.Data;
using MovieStore.Models;
using MovieStore.Services.Abstract;

namespace MovieStore.Services.Implementation
{
    public class MovieService : IMovieService
    {

        private readonly AppDbContext _db;
        public MovieService(AppDbContext db)
        {
            _db = db;
        }
        public List<Movie> GetTop5Movies()
        {
            return _db.Movies.OrderByDescending(m => m.Price).Take(5).ToList();
        }

        public List<Movie> GetTop5NewestMovies()
        {
            return _db.Movies.OrderByDescending(m => m.ReleaseYear).Take(5).ToList();
        }

        public List<Movie> GetTop5OldestMovies()
        {
            return _db.Movies.OrderBy(m => m.ReleaseYear).Take(5).ToList();
        }

        public List<Movie> GetMovies()
        {
            return _db.Movies.ToList();
        }
        public void CreateMovie(Movie movie)
        {
            _db.Movies.Add(movie);
            _db.SaveChanges();
        }



    }
}
