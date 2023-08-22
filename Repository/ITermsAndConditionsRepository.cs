using Aplication.Client.API.Models;

namespace Aplication.Client.API.Repository
{
    public interface ITermsAndConditionsRepository
    {
        Task<TermsAndConditions> GetTermsAndConditions();
    }
}
