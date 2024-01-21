using Microsoft.AspNetCore.Mvc;

namespace ShopCar.Controllers
{
    public class ShopCarController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
