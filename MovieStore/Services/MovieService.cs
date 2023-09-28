using MovieStore.Data;
using MovieStore.Models;

namespace MovieStore.Services
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

        //public Movie GetMovieById(int id)
        //{
        //    var movie = _db.Movies.Find(id);

        //    if (movie == null)
        //    {
        //        throw new Exception("Movie not found");
        //    }

        //    return movie;
        //}

    }
}
