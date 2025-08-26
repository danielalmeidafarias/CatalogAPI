using CatalogAPI.Catalog.Domain.Entities;
using CatalogAPI.Catalog.Domain.Interfaces;

namespace CatalogAPI.Catalog.Application.Products.Handlers
{
    public class ListProductsUseCase
    {
        private readonly IProductsRepository _productRepository;
        public ListProductsUseCase(IProductsRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<IEnumerable<Product>> Execute()
        {
            var products = await _productRepository.GetAll();
            return products;
        }
    }
}
