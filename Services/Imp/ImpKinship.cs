using Aplication.Client.API.DTO;
using Aplication.Client.API.Models;
using Aplication.Client.API.Repository;

namespace Aplication.Client.API.Services.Imp
{
    public class ImpKinship : IKinship
    {
        private IKinshipRepository _kinshipRepository;

        public ImpKinship(IKinshipRepository kinshipRepository)
        {
            _kinshipRepository = kinshipRepository;
        }


        public async Task<List<Kinship>> GetKinshipCatalog()
        {
            return  await _kinshipRepository.GetKinshipCatalog();
        }
    }
}
