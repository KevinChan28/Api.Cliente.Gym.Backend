using Aplication.Client.API.Models;

namespace Aplication.Client.API.Repository
{
    public interface IAddressRepository
    {
        public Task<int> RegisterAddress(Address address);
        public Task<Address> GetAddressByAddressId(int idAddress);
        public Task<int> UpdateAddress(Address address);
    }
}
