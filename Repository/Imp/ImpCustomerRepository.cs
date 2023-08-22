using Aplication.Client.API.Context;
using Aplication.Client.API.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Aplication.Client.API.Repository.Imp
{
    public class ImpCustomerRepository : ICustomerRepository
    {
        DBContext _context;


        public ImpCustomerRepository(DBContext context)
        {
            _context = context;
        }


        public async Task<int> AddCustomer(Customer customer)
        {
            EntityEntry<Customer> entityEntryCustomer = await _context.Customer.AddAsync(customer);
            await _context.SaveChangesAsync();

            return entityEntryCustomer.Entity.Id;
        }

        public async Task<bool> EmailExist(string email)
        {
            return _context.Customer.Where(p => p.Email == email).Any();
        }

        public async Task<Customer> GetCustomerById(int customerId)
        {
          return _context.Customer.Select(p => p).Where(x => x.Id == customerId).FirstOrDefault();
        }

        public async Task<int> UpdateDataOFCustomer(Customer customer)
        {
            EntityEntry<Customer> entityEntryUpdate = _context.Customer.Update(customer);
            await _context.SaveChangesAsync();

            return entityEntryUpdate.Entity.Id;
        }
    }
}
