using Aplication.Client.API.DTO;
using Aplication.Client.API.Models;

namespace Aplication.Client.API.Services
{
    public interface ICustomer
    {
        public Task<int> CustumerRegister(CustomerRegister customerData);
        Task<Customer> GetCustomerById(int customerId);
        Task<int> UpdateDataOfCustomer(CustomerUpdate customerDataUpdate);
        Task<bool> EmailExist(string email);
    }

}
