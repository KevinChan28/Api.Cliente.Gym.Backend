using Aplication.Client.API.Context;
using Aplication.Client.API.Models;
using Aplication.Client.API.Services;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Aplication.Client.API.Repository.Imp
{
    public class ImpAddressRepository : IAddressRepository
    {
        DBContext _context;

        public ImpAddressRepository(DBContext context)
        {
            _context = context;
        }


        public async Task<Address> GetAddressByAddressId(int idAddress)
        {
            return _context.Address.Select(a => a).Where(x => x.Id == idAddress).FirstOrDefault();
        }

        public async Task<int> RegisterAddress(Address address)
        {
            EntityEntry<Address> entityEntryAddress = await _context.AddAsync(address);
            await _context.SaveChangesAsync();
            return entityEntryAddress.Entity.Id;
        }

        public async Task<int> UpdateAddress(Address address)
        {
            EntityEntry<Address> entityEntryUpdateAddress = _context.Address.Update(address);
            await _context.SaveChangesAsync();

            return entityEntryUpdateAddress.Entity.Id;
        }
    }
}
