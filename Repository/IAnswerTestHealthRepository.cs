using Aplication.Client.API.Models;

namespace Aplication.Client.API.Repository
{
    public interface IAnswerTestHealthRepository
    {
        Task<List<TestHealth>> GetAnswerTestHealth();
    }
}
