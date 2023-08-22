using Aplication.Client.API.Models;

namespace Aplication.Client.API.Repository
{
    public interface IPoliticsRepository
    {
        Task<Politics> GetPoliticsGymnasium();
    }
}
