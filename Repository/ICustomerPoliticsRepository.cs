using Aplication.Client.API.Models;

namespace Aplication.Client.API.Repository
{
    public interface ICustomerPoliticsRepository
    {
        Task<int> CustomerPoliticsSave(CustomerPolitics customerPolitics);
    }
}
