using CatalogAPI.Catalog.Domain.Interfaces;
using CatalogAPI.Catalog.Domain.Entities;

namespace CatalogAPI.Catalog.Application.Products.Handlers
{
    public class GetProductByIDUseCase
    {
        private readonly IProductsRepository _productRepository;

        public GetProductByIDUseCase(IProductsRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Product> Execute(Guid id)
        {
            try
            {
                var product = await _productRepository.GetOneByID(id);
                return product is null ? throw new Exception("Product not found") : product;
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting product", ex);
            }
        }
    }
}
