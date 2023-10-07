using Microsoft.AspNetCore.Mvc;
using MovieStore.Helpers;
namespace MovieStore.Controllers
{
    public class OrderController : Controller
    {
        public OrderController()
        {
            
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddToCart(string id)
        { 
          if (HttpContext.Session.Get<List<int>>("movieIdlist")==default)
            {
                HttpContext.Session.Set<List<int>>("movieIdlist", new List<int>());
            }
            var movieIdList = HttpContext.Session.Get<List<int>>("movieIdlist");
            movieIdList.Add(Convert.ToInt32(id));

            HttpContext.Session.Set<List<int>>("movieIdlist", movieIdList);
            return Json(movieIdList.Count);
        }
    }
}
