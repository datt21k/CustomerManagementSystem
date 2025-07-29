using CustomerManagementSystem.Services;
using CustomerManagementSystem.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CustomerManagementSystem.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;
        private readonly ILogger<CustomerController> _logger;

        public CustomerController(ICustomerService customerService, ILogger<CustomerController> logger)
        {
            _customerService = customerService;
            _logger = logger;
        }

        // GET: Customer
        public async Task<IActionResult> Index()
        {
            try
            {
                var customers = await _customerService.GetAllCustomersAsync();
                return View(customers);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving customers");
                return View("Error");
            }
        }

        // GET: Customer/Details/5
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var customer = await _customerService.GetCustomerByIdAsync(id);
                if (customer == null)
                {
                    return NotFound();
                }
                return View(customer);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving customer details");
                return View("Error");
            }
        }

        // GET: Customer/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Customer/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CustomerViewModel customer)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _customerService.CreateCustomerAsync(customer);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error creating customer");
                    ModelState.AddModelError("", "Unable to create customer. Please try again.");
                }
            }
            return View(customer);
        }

        // GET: Customer/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var customer = await _customerService.GetCustomerByIdAsync(id);
                if (customer == null)
                {
                    return NotFound();
                }
                return View(customer);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving customer for edit");
                return View("Error");
            }
        }

        // POST: Customer/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CustomerViewModel customer)
        {
            if (id != customer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _customerService.UpdateCustomerAsync(customer);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error updating customer");
                    ModelState.AddModelError("", "Unable to update customer. Please try again.");
                }
            }
            return View(customer);
        }

        // GET: Customer/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var customer = await _customerService.GetCustomerByIdAsync(id);
                if (customer == null)
                {
                    return NotFound();
                }
                return View(customer);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving customer for deletion");
                return View("Error");
            }
        }

        // POST: Customer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _customerService.DeleteCustomerAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting customer");
                return View("Error");
            }
        }
    }
}
