using Microsoft.AspNetCore.Mvc;

namespace OnlineShop.WebApi.Controllers
{
    public class OrdersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
