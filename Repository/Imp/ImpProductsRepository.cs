using Aplication.Client.API.Context;
using Aplication.Client.API.Models;

namespace Aplication.Client.API.Repository.Imp
{
    public class ImpProductsRepository : IProductsRepository
    {
        DBContext _context;
        public ImpProductsRepository(DBContext context)
        {
            _context = context;
        }

        public async Task<List<Products>> GetAllProducts()
        {
            return _context.Products.AsEnumerable<Products>().ToList();
        }

        public async Task<int> ProductSale(IncomeProduct incomeProduct)
        {
            _context.IncomeProduct.Add(incomeProduct);
            return await _context.SaveChangesAsync();
        }
    }
}
