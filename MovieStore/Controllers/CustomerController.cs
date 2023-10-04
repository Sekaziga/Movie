using MovieStore.Models;
using Microsoft.AspNetCore.Mvc;
using MovieStore.Services.Abstract;

namespace MovieStore.Controllers
{
    public class CustomerController : Controller
    {


        private readonly ILogger<CustomerController> _logger;
        private readonly ICustomerService _customerService;

        public CustomerController(ILogger<CustomerController> logger, ICustomerService customerService)
        {
            _logger = logger;
            _customerService = customerService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Customer newCustomer)
        {
            _customerService.CreateCustomer(newCustomer);
            return View();
        }



        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}
