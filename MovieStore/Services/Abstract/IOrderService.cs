using MovieStore.Models;
using MovieStore.Models.ViewModels;

using System.Collections.Generic;


namespace MovieStore.Services
{
    public interface IOrderService
    {

        List<Movie> GetMostSoldMovies();
        CartVM GetCartVM(List<int> movieIdList);


        void AddOrder(string email, List<CartMovieVM> cartMovies);

    }
}
