using Aplication.Client.API.Context;
using Aplication.Client.API.Models;

namespace Aplication.Client.API.Repository.Imp
{
    public class ImpKinshipRepository : IKinshipRepository
    {
        DBContext _context;

        public ImpKinshipRepository(DBContext context)
        {
            _context = context;
        }

        public async Task<List<Kinship>> GetKinshipCatalog()
        {
            return _context.Kinship.AsEnumerable<Kinship>().ToList();
        }
    }
}
