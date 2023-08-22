using Aplication.Client.API.Models;

namespace Aplication.Client.API.Repository
{
    public interface IPoliticsTypeRepository
    {
      Task<List<PoliticsType>> GetPoliticsTypeGimansium();
    }
}
