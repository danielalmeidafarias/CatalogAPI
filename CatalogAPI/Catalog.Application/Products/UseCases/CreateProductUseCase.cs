using CatalogAPI.Catalog.Domain.Interfaces;
using CatalogAPI.Catalog.Domain.Entities;


namespace CatalogAPI.Catalog.Application.Products.Handlers
{
    public class CreateProductUseCase
    {
        private readonly IProductsRepository _productRepository;

        public CreateProductUseCase(IProductsRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Guid> Execute(Product input)
        {
            var product = new Domain.Entities.Product(input.Name, input.Price, input.Description);
            await _productRepository.CreateOne(product);

            return product.Id;
        }
    }
}
