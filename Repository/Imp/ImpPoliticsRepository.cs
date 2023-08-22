using Aplication.Client.API.Models;
using Microsoft.EntityFrameworkCore;
using Aplication.Client.API.Context;

namespace Aplication.Client.API.Repository.Imp
{
    public class ImpPoliticsRepository : IPoliticsRepository
    {
        DBContext _context;


        public ImpPoliticsRepository(DBContext context)
        {
            _context = context;
        }

        public async Task<Politics> GetPoliticsGymnasium()
        {
            return await _context.Politics.FirstOrDefaultAsync();
        }
    }
}
