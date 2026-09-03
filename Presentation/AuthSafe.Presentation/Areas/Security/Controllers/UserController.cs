using Microsoft.AspNetCore.Mvc;

namespace AuthSafe.Presentation.Areas.Security.Controllers
{
    [Area("Security")]
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View("UserIndex");
        }
    }
}
