using Aplication.Client.API.DTO;

namespace Aplication.Client.API.Services
{
    public interface ICustomerAnswerTest
    {
       public Task<int> CostumerAnswerTest(CustomerAnswerTestRegister customerAnswerTestRegister);
    }
}
