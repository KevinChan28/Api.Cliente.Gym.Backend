using Aplication.Client.API.Models;

namespace Aplication.Client.API.Repository
{
    public interface IProductsRepository
    {
        Task<List<Products>> GetAllProducts();
        Task<int> ProductSale(IncomeProduct incomeProduct);
    }
}
