using MovieStore.Models;
using Microsoft.AspNetCore.Mvc;
using MovieStore.Models.ViewModels;
using MovieStore.Services;

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
            var customerList = _customerService.GetCustomers();
            return View(customerList);
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

            //if (TempData["createorder"] is not null)
            //{
            //    return RedirectToAction("ConfirmOrder", "Order", new { newCustomer.Email });
            //}

            return RedirectToAction("Index");

        }

        public IActionResult CheckOut()
        {

            return View();
        }

        [HttpPost]

        public IActionResult CheckOut(string email)
        {
            if (_customerService.CheckExists(email))
            {
                return RedirectToAction("ConfirmOrder", "Order", new { email });
            }

            TempData["createorder"] = "yes";
            return RedirectToAction("Create");
        }


        public IActionResult ThankYou()
        {
            return View();
        }

    }
}
