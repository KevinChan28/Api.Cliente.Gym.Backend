using Aplication.Client.API.DTO;
using Aplication.Client.API.Models;
using Aplication.Client.API.Repository;

namespace Aplication.Client.API.Services.Imp
{
    public class ImpProducts : IProducts
    {
        private IProductsRepository _productsRepository;
        public ImpProducts(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        public async Task<int> ProductSale(ProductSale sellProduct)
        {
            IncomeProduct incomeProduct = new IncomeProduct()
            {
                ProductId = sellProduct.ProductId,
                Concept = sellProduct.Concept,
                Price = sellProduct.Price * sellProduct.Quantity,
                Quantity = sellProduct.Quantity,
                CreatedDate = DateTime.Now
            };

            int result = await _productsRepository.ProductSale(incomeProduct);
            return result;
        }

        public async Task<List<CatalogProducts>> GetCatalogProducts()
        {
            List<Products> products = await _productsRepository.GetAllProducts();
            List<CatalogProducts> result = products.Select(p => new CatalogProducts 
                { 
                    Id = p.Id, 
                    ProductName = p.ProductName
                }).ToList();
            
            return result;
        }
    }
}
