using MovieStore.Models;
using MovieStore.Models.ViewModels;
using System.Collections.Generic;

namespace MovieStore.Services.Abstract
{
    public interface IOrderService
    {
        List<Order> GetOrders();

        //List<Movie> GetmostSoldMovies();
        CartVM GetCartVM(List<int> movieIdList);



        void CreateOrder(Order newOrder);
        bool UpdateOrder(Order newOrder);

        Order GetOrderById(int id);
        bool DeleteOrder(int id);
    }
}
