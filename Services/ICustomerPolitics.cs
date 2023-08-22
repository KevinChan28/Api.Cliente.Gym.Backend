using Aplication.Client.API.DTO;

namespace Aplication.Client.API.Services
{
    public interface ICustomerPolitics
    {
        Task<int> CustomerPoliticsSave(CustomerPoliticsSave customerPoliticsSave);
    }
}
