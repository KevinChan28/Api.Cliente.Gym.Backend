using Aplication.Client.API.DTO;
using Aplication.Client.API.Models;

namespace Aplication.Client.API.Services
{
    public interface IPolitics
    {
       public Task<PoliticsDTO> GetPoliticsGymnasium();
    }
}
