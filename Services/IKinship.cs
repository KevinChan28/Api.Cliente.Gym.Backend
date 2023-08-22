using Aplication.Client.API.DTO;
using Aplication.Client.API.Models;

namespace Aplication.Client.API.Services
{
    public interface IKinship
    {
        Task<List<Kinship>> GetKinshipCatalog();
    }
}
