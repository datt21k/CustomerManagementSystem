using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CustomerManagementSystem.Models;
using CustomerManagementSystem.Services;

namespace CustomerManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly CustomerService _customerService;

        public HomeController(ILogger<HomeController> logger, CustomerService customerService)
        {
            _logger = logger;
            _customerService = customerService;
        }

        public IActionResult Index()
        {
            ViewBag.TotalCustomers = _customerService.GetCustomerCount();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}