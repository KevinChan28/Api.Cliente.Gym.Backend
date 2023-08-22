using Aplication.Client.API.Models;

namespace Aplication.Client.API.Repository
{
    public interface ICustomerRepository
    {
        Task<int> AddCustomer(Customer customer);
        Task<Customer> GetCustomerById(int customerId);
        Task<int> UpdateDataOFCustomer(Customer customer);
        Task<bool> EmailExist(string email);
    }

}
