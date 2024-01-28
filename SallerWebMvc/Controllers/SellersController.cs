using Microsoft.AspNetCore.Mvc;

namespace SallerWebMvc.Controllers
{
    public class SellersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
