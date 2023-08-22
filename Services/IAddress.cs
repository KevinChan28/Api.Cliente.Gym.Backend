using Aplication.Client.API.DTO;
using Aplication.Client.API.Models;

namespace Aplication.Client.API.Services
{
    public interface IAddress
    {
        Task<Address> GetAddressByAddressId(int idAddress);
        Task<int> UpdateAddress(Address updateDataAddress);
    }
}
