using MovieStore.Data;
using MovieStore.Models;
using MovieStore.Services.Abstract;

namespace MovieStore.Services.Implementation
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
