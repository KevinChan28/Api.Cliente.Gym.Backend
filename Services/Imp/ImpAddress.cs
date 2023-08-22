using Aplication.Client.API.DTO;
using Aplication.Client.API.Models;
using Aplication.Client.API.Repository;

namespace Aplication.Client.API.Services.Imp
{
    public class ImpAddress:IAddress
    {
        IAddressRepository _addressRepository;

        public ImpAddress(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }


        public async Task<Address> GetAddressByAddressId(int idAddress)
        {
            return await _addressRepository.GetAddressByAddressId(idAddress);
        }

        public async Task<int> UpdateAddress(Address updateDataAddress)
        {
            Address address = await _addressRepository.GetAddressByAddressId(updateDataAddress.Id);
            if (address != null)
            {
                address.Street = updateDataAddress.Street;
                address.InteriorNumber = updateDataAddress.InteriorNumber;
                address.OutdoorNumber = updateDataAddress.OutdoorNumber;
                address.Neighborhood = updateDataAddress.Neighborhood;
                address.ZipCode = updateDataAddress.ZipCode;
                address.Locality = updateDataAddress.Locality;
                address.Municipaly = updateDataAddress.Municipaly;
                address.Nationality = updateDataAddress.Nationality;
                await _addressRepository.UpdateAddress(address);

                return address.Id;
            }
            return 0;
        }
    }
}
