using Aplication.Client.API.Models;

namespace Aplication.Client.API.Repository
{
    public interface ICustomerAnswerTestRepository
    {
       Task<int> SaveTestQuestions(List<CustomerAnswerTest> customerAnswerTest);
    }
}
