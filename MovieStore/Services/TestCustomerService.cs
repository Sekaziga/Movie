using MovieStore.Models;


namespace MovieStore.Services
{
    public class TestCustomerService
    {
        List<Customer> Customers { get; set; } = new List<Customer>();
        public void CreateCustomer(Customer newCustomer)
        {
            Customers.Add(newCustomer);
        }
    }
}
