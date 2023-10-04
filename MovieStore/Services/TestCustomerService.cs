using MovieStore.Models;
using MovieStore.Services.Abstract;

namespace MovieStore.Services
{
    public class TestCustomerService : ICustomerService
    {
        List<Customer> Customers { get; set; } = new List<Customer>();
        public void CreateCustomer(Customer newCustomer)
        {
            Customers.Add(newCustomer);
        }
    }
}
