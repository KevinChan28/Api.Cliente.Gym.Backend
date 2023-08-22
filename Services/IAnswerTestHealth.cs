using Aplication.Client.API.DTO;

namespace Aplication.Client.API.Services
{
    public interface IAnswerTestHealth
    {
        Task<TestDTO> GetAnswerTestHealth();
    }
}
