using Aplication.Client.API.Models;

namespace Aplication.Client.API.Repository
{
    public interface IIdentificationImageRepository
    {
        public Task<int> AddIdentificationImage(IdentificationImage identificationImage);
    }
}
