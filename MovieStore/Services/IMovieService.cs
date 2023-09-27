using MovieStore.Models;

namespace MovieStore.Services
{
    public interface IMovieService
    {

        void CreateMovie(Movie newMovie);

        List<Movie> GetMovies();

    }
}
