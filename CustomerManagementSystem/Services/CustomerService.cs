using CustomerManagementSystem.Models;
using CustomerManagementSystem.Repositories;
using CustomerManagementSystem.ViewModels;

namespace CustomerManagementSystem.Services
{
    public interface ICustomerService
    {
        Task<IEnumerable<CustomerViewModel>> GetAllCustomersAsync();
        Task<CustomerViewModel?> GetCustomerByIdAsync(int id);
        Task<CustomerViewModel> CreateCustomerAsync(CustomerViewModel customerVm);
        Task UpdateCustomerAsync(CustomerViewModel customerVm);
        Task DeleteCustomerAsync(int id);
    }

    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _repository;

        public CustomerService(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<CustomerViewModel>> GetAllCustomersAsync()
        {
            var customers = await _repository.GetAllAsync();
            return customers.Select(ToViewModel);
        }

        public async Task<CustomerViewModel?> GetCustomerByIdAsync(int id)
        {
            var customer = await _repository.GetByIdAsync(id);
            return customer != null ? ToViewModel(customer) : null;
        }

        public async Task<CustomerViewModel> CreateCustomerAsync(CustomerViewModel customerVm)
        {
            var customer = ToModel(customerVm);
            customer = await _repository.CreateAsync(customer);
            return ToViewModel(customer);
        }

        public async Task UpdateCustomerAsync(CustomerViewModel customerVm)
        {
            var customer = ToModel(customerVm);
            await _repository.UpdateAsync(customer);
        }

        public async Task DeleteCustomerAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        private static CustomerViewModel ToViewModel(Customer customer)
        {
            return new CustomerViewModel
            {
                Id = customer.Id,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Email = customer.Email,
                PhoneNumber = customer.PhoneNumber,
                StreetAddress = customer.StreetAddress,
                City = customer.City,
                State = customer.State,
                PostalCode = customer.PostalCode,
                Country = customer.Country,
                Occupation = customer.Occupation,
                Company = customer.Company,
                CreatedAt = customer.CreatedAt,
                UpdatedAt = customer.UpdatedAt
            };
        }

        private static Customer ToModel(CustomerViewModel vm)
        {
            return new Customer
            {
                Id = vm.Id,
                FirstName = vm.FirstName,
                LastName = vm.LastName,
                Email = vm.Email,
                PhoneNumber = vm.PhoneNumber,
                StreetAddress = vm.StreetAddress,
                City = vm.City,
                State = vm.State,
                PostalCode = vm.PostalCode,
                Country = vm.Country,
                Occupation = vm.Occupation,
                Company = vm.Company,
                CreatedAt = vm.CreatedAt,
                UpdatedAt = vm.UpdatedAt
            };
        }
    }
}
