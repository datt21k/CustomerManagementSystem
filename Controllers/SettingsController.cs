using Microsoft.AspNetCore.Mvc;

namespace CustomerManagementSystem.Controllers
{
    public class SettingsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}