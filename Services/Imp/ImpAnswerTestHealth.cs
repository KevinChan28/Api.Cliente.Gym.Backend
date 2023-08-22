using System.Linq;
using Aplication.Client.API.DTO;
using Aplication.Client.API.Models;
using Aplication.Client.API.Repository;
using Org.BouncyCastle.Crypto;

namespace Aplication.Client.API.Services.Imp
{
    public class ImpAnswerTestHealth : IAnswerTestHealth
    {
        private IAnswerTestHealthRepository _answerTestHealthnRepository;

        public ImpAnswerTestHealth(IAnswerTestHealthRepository answerTestHealthRepository)
        {
            _answerTestHealthnRepository = answerTestHealthRepository;
        }


        public async Task<TestDTO> GetAnswerTestHealth()
        {
            List<TestHealth> AnswerTestData = await _answerTestHealthnRepository.GetAnswerTestHealth();
            TestDTO test = new TestDTO();
            test.TestId = AnswerTestData.FirstOrDefault().TestId;
            test.Name = AnswerTestData.FirstOrDefault().Name;
            test.DescriptionTest = AnswerTestData.FirstOrDefault().DescriptionTest;
            test.IntructionsTest = AnswerTestData.FirstOrDefault().IntructionsTest;
            test.Questions = AnswerTestData.DistinctBy(p => p.QuestionId).Select(p => new QuestionTest 
            {
                QuestionId = p.QuestionId,
                DescriptionQuestion = p.DescriptionQuestion,
                Answer = AnswerTestData.Where(x => x.QuestionId == p.QuestionId).Select(q => new TestAnswer
                {
                    AnswerId = q.AnswerId,
                    DescriptionAnswer = q.DescriptionAnswer,
                    RequirePersonalizedDescription = q.RequirePersonalizedDescription,
                    ComponentType = q.ComponentType
               }).ToList()
            }).ToList();
            return test;
        }
    }
}