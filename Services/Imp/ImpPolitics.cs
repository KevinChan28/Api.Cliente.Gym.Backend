using Aplication.Client.API.DTO;
using Aplication.Client.API.Models;
using Aplication.Client.API.Repository;

namespace Aplication.Client.API.Services.Imp
{
    public class ImpPolitics : IPolitics
    {
        private IPoliticsRepository _politicsRepository;
        private ITermsAndConditionsRepository _tremsAndConditionsRepository;

        public ImpPolitics(IPoliticsRepository politicsRepository, ITermsAndConditionsRepository termsAndConditionsRepository)
        {
            _politicsRepository = politicsRepository;
            _tremsAndConditionsRepository = termsAndConditionsRepository;
        }

     
        public async Task<PoliticsDTO> GetPoliticsGymnasium()
        {
            Politics politics = await _politicsRepository.GetPoliticsGymnasium();
            if (politics == null)
            {
                return null;
            }

            TermsAndConditions termsAndConditions = await _tremsAndConditionsRepository.GetTermsAndConditions();
            if (termsAndConditions == null)
            {
                return null;
            }

            PoliticsDTO result = new PoliticsDTO
            {
                IdPolitics = politics.Id,
                Description = politics.Description,
                TermsAndConditionsCustomer = new TermsAndConditionsCustomer
                {
                    IdTermsAndConditions = termsAndConditions.Id,
                    PoliticsId = termsAndConditions.PoliticsId,
                    Description = termsAndConditions.Description
                }
            };

            return result;
        }
    }
}
    
