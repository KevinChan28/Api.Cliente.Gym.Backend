using Aplication.Client.API.DTO;
using Aplication.Client.API.Models;
using Aplication.Client.API.Repository;

namespace Aplication.Client.API.Services.Imp
{
    public class ImpCustomerAnswerTest : ICustomerAnswerTest
    {
        private readonly ICustomerAnswerTestRepository _customerAnswerTestRepository;

        public ImpCustomerAnswerTest(ICustomerAnswerTestRepository customerAnswerTestRepository)
        {
            _customerAnswerTestRepository = customerAnswerTestRepository;
        }

        public async Task<int> CostumerAnswerTest(CustomerAnswerTestRegister customerAnswerTestRegister)
        {
            List<CustomerAnswerTest> customerAnswerTests = customerAnswerTestRegister.QuestionsAnswereds.Select(
                    p => new CustomerAnswerTest
                    {
                        TestId = customerAnswerTestRegister.TestId,
                        CustomerId = customerAnswerTestRegister.CustomerId,
                        QuestionId = p.QuestionId,
                        TestAnswerId = p.AnswerId,
                        PersonalizedDescriptionAnswer = p.PersonlizedAnswer
                    }).ToList();

            return await _customerAnswerTestRepository.SaveTestQuestions(customerAnswerTests);
        }
    }
}

