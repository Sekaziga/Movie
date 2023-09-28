using MovieStore.Models;

namespace MovieStore.Services
{
    public interface IMovieService
    {

        void CreateMovie(Movie newMovie);
        //void DeleteMovie(Movie newMovie);
        //void DetailMovie(Movie newMovie);
        List<Movie> GetMovies();
        //void UpdateMovie(Movie newMovie);

        //void UpdateMovie(Movie newMovie);
        //void DeleteMovie(Movie newMovie);
        //void DetailMovie(Movie newMovie);
    }
}
