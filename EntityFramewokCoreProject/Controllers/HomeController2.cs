using Microsoft.AspNetCore.Mvc;

namespace EntityFramewokCoreProject.Controllers
{
    public class HomeController2 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
