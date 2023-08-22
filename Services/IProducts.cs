using Aplication.Client.API.DTO;
using Aplication.Client.API.Models;

namespace Aplication.Client.API.Services
{
    public interface IProducts
    {
        Task<List<CatalogProducts>> GetCatalogProducts();
        Task<int> ProductSale(ProductSale sellProduct);

    }
}
