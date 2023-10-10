using MovieStore.Data;
using MovieStore.Models;


namespace MovieStore.Services
{
    public class CustomerService : ICustomerService
    {

        private readonly AppDbContext _db;

        public CustomerService(AppDbContext db)
        {
            _db = db;
        }
        public void CreateCustomer(Customer newCustomer)
        {
            _db.Customers.Add(newCustomer);
            _db.SaveChanges();
        }

        public bool CheckExists(string email)
        {
            return _db.Customers.Any(c => c.Email == email);
        }

        public Customer GetCustomer(string email)
        {
            return _db.Customers.Where(c => c.Email == email).FirstOrDefault();
        }

        public List<Customer> GetCustomers()
        {
            return _db.Customers.ToList();
        }








    }
}
