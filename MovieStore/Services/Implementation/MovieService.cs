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

        public List<Movie> GetMovies()
        {
            return _db.Movies.ToList();
        }
        public void CreateMovie(Movie movie)
        {
            _db.Movies.Add(movie);
            _db.SaveChanges();
        }

        public Movie GetMovie(int id)
        {
            return _db.Movies.Where(m => m.Id == id).FirstOrDefault();
        }



    }
}
