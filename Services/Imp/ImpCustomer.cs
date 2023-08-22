using Aplication.Client.API.DTO;
using Aplication.Client.API.Models;
using Aplication.Client.API.Repository;

namespace Aplication.Client.API.Services.Imp
{
    public class ImpCustomer : ICustomer
    {
        private IIdentificationImageRepository _identificationImageRepository;
        private ISocialMediaRepository _socialMediaRepository;
        private IAddressRepository _addressRepository;
        private ICustomerRepository _customerRepository;

        public ImpCustomer(IIdentificationImageRepository identificationImageRepository, ISocialMediaRepository socialMediaRepository, IAddressRepository addressRepository,
                ICustomerRepository customerRepository)
        {
            _identificationImageRepository = identificationImageRepository;
            _socialMediaRepository = socialMediaRepository;
            _addressRepository = addressRepository;
            _customerRepository = customerRepository;
        }

        public async Task<int> CustumerRegister(CustomerRegister customerData)
        {
            IdentificationImage identificationImage = new IdentificationImage
            {
                PathImage = customerData.IdentificationImage.PathImage,
                MimeType = customerData.IdentificationImage.MimeType,
            };
            int identificationImageId = await _identificationImageRepository.AddIdentificationImage(identificationImage);

            Customer customer = new Customer
            {
                IdentificationImageId = identificationImageId,
                Name = customerData.Name,
                LastName = customerData.LastName,
                Email = customerData.Email,
                Phone = customerData.Phone,
                Birthdate = customerData.Birthdate,
                CreatedDate = DateTime.UtcNow
            };
            if (customerData.Email == "")
            {
                customer.Email = null;
            }

            int customerId = await _customerRepository.AddCustomer(customer);

            return customerId;
        }

        public async Task<bool> EmailExist(string email)
        {
            return await _customerRepository.EmailExist(email);
        }

        public async Task<Customer> GetCustomerById(int customerId)
        {
            return await _customerRepository.GetCustomerById(customerId);
        }

        public async Task<int> UpdateDataOfCustomer(CustomerUpdate customerDataUpdate)
        {
            Customer customer = await _customerRepository.GetCustomerById(customerDataUpdate.Id);
            if (customer != null)
            {
                customer.Name = customerDataUpdate.Name;
                customer.LastName = customerDataUpdate.LastName;
                customer.Email = customerDataUpdate.Email;
                customer.Birthdate = customerDataUpdate.Birthdate;
                customer.Phone = customerDataUpdate.Phone;
                await _customerRepository.UpdateDataOFCustomer(customer);
                return customer.Id;
            }
            return 0;
        }
    }
}
