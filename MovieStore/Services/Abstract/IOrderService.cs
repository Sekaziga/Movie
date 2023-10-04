using MovieStore.Models;

namespace MovieStore.Services.Abstract
{
    public interface IOrderService
    {
        List<Order> GetOrders();



        void CreateOrder(Order newOrder);
        bool UpdateOrder(Order newOrder);

        Order GetOrderById(int id);
        bool DeleteOrder(int id);
    }
}
