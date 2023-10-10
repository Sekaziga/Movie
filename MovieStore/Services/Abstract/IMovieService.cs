using MovieStore.Models;

namespace MovieStore.Services
{
    public interface IMovieService
    {

        List<Movie> GetMovies();
        Movie GetMovie(int id);
        void CreateMovie(Movie newMovie);

    }
}
