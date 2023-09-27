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








    }
}
