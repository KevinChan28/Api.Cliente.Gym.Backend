using Aplication.Client.API.Context;
using Aplication.Client.API.Models;

namespace Aplication.Client.API.Repository.Imp
{
    public class ImpCustomerPoliticsRepository : ICustomerPoliticsRepository
    {
        DBContext _context;

        public ImpCustomerPoliticsRepository(DBContext context)
        {
            _context = context;
        }


        public async Task<int> CustomerPoliticsSave(CustomerPolitics customerPolitics)
        {
            _context.CustomerPolitics.Add(customerPolitics);
            return await _context.SaveChangesAsync();
        }
    }
}
