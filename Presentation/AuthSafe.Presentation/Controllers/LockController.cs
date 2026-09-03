using Microsoft.AspNetCore.Mvc;

namespace AuthSafe.Presentation.Controllers
{
    public class LockController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
