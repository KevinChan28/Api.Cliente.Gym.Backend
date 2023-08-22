using Aplication.Client.API.Context;
using Aplication.Client.API.Models;

namespace Aplication.Client.API.Repository.Imp
{
    public class ImpPoliticsTypeRepository : IPoliticsTypeRepository
    {
        DBContext _context;

        public ImpPoliticsTypeRepository(DBContext context)
        {
            _context = context;
        }

        public async Task<List<PoliticsType>> GetPoliticsTypeGimansium()
        {
            return _context.PoliticsType.AsEnumerable<PoliticsType>().ToList();
        }
    }
}
