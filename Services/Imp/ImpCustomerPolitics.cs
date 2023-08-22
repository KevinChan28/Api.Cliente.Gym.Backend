using Aplication.Client.API.DTO;
using Aplication.Client.API.Models;
using Aplication.Client.API.Repository;

namespace Aplication.Client.API.Services.Imp
{
    public class ImpCustomerPolitic : ICustomerPolitics
    {
        private ICustomerPoliticsRepository _customerPoliticsRepository;

        public ImpCustomerPolitic(ICustomerPoliticsRepository customerPoliticsRepository)
        {
            _customerPoliticsRepository = customerPoliticsRepository;
        }
        public async Task<int> CustomerPoliticsSave(CustomerPoliticsSave customerPoliticsSave)
        {
            CustomerPolitics customerPolitics = new CustomerPolitics()
            {
                CustomerId = customerPoliticsSave.CustomerId,
                TutorId = customerPoliticsSave.TutorId,
                PoliticsId = customerPoliticsSave.PoliticsId,  
                IsAccepted = customerPoliticsSave.IsAccepted
            
            };

            int result = await _customerPoliticsRepository.CustomerPoliticsSave(customerPolitics);
            return result;
        }
    }
}
