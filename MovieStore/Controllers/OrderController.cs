using Microsoft.AspNetCore.Mvc;

namespace MovieStore.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
