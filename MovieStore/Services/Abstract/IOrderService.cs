using MovieStore.Models;
using System.Collections.Generic;

namespace MovieStore.Services.Abstract
{
    public interface IOrderService
    {
        List<Order> GetOrders();

        List<Movie> GetmostSoldMovies();
        List<Movie> GetCartVM(List<int> movieIdList);



        void CreateOrder(Order newOrder);
        bool UpdateOrder(Order newOrder);

        Order GetOrderById(int id);
        bool DeleteOrder(int id);
    }
}
