using Aplication.Client.API.Models;

namespace Aplication.Client.API.Repository
{
    public interface IKinshipRepository
    {
        Task<List<Kinship>> GetKinshipCatalog();
    }
}
