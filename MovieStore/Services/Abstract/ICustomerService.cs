using MovieStore.Models;

namespace MovieStore.Services
{
    public interface ICustomerService
    {

        void CreateCustomer(Customer newCustomer);

        bool CheckExists(string email);

        Customer GetCustomer(string email);

        public List<Customer> GetCustomers();
    }
}
