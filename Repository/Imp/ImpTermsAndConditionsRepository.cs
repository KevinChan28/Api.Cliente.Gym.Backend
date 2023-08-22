using Aplication.Client.API.Context;
using Aplication.Client.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Aplication.Client.API.Repository.Imp
{
    public class ImpTermsAndConditionsRepositor : ITermsAndConditionsRepository
    {
        DBContext _context;


        public ImpTermsAndConditionsRepositor(DBContext context)
        {
            _context = context;
        }


        public async Task<TermsAndConditions> GetTermsAndConditions()
        {
            return  await _context.TermsAndConditions.FirstOrDefaultAsync();
        }
    }
}
