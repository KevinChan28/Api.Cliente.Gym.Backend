using Aplication.Client.API.Context;
using Aplication.Client.API.Models;
using Aplication.Client.API.Services;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Aplication.Client.API.Repository.Imp
{
    public class ImpCustomerAnswerTestRepository : ICustomerAnswerTestRepository
    {
        DBContext _context;


        public ImpCustomerAnswerTestRepository(DBContext context)
        {
            _context = context;
        }


        public async Task<int> SaveTestQuestions(List<CustomerAnswerTest> customerAnswerTest)
        {
            await _context.CustomerAnswerTests.AddRangeAsync(customerAnswerTest);

            return await _context.SaveChangesAsync();
        }
    }
}
