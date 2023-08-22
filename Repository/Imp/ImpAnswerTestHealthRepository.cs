using System.Linq;
using Aplication.Client.API.Context;
using Aplication.Client.API.Models;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Crypto;

namespace Aplication.Client.API.Repository.Imp
{
    public class ImpAnswerTestHealthRepository : IAnswerTestHealthRepository
    {
        DBContext _context;
        public ImpAnswerTestHealthRepository(DBContext context)
        {
            _context = context;
        }

        public async Task<List<TestHealth>> GetAnswerTestHealth()
        {
            return await _context.TestHealth.FromSqlInterpolated($"Call GetAnswerHealth ()").ToListAsync();
        }
    }
}
