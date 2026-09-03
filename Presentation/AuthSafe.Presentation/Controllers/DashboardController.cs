using Microsoft.AspNetCore.Mvc;

namespace AuthSafe.Presentation.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
