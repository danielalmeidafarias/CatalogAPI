using CatalogAPI.Catalog.Domain.Interfaces;
using CatalogAPI.Catalog.Domain.Entities;

namespace CatalogAPI.Catalog.Application.Products.Handlers
{
    public class UpdateProductUseCase
    {
        private readonly IProductsRepository _productRepository;

        public UpdateProductUseCase(IProductsRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Product> Execute(Product product)
        {
            var existingProduct = await _productRepository.GetOneByID(product.Id);
            if (existingProduct is null)
                throw new Exception("Product not found");
         
            await _productRepository.Update(existingProduct);

            return product;
        }
    }
}
