using CatalogAPI.Catalog.Domain.Interfaces;
using CatalogAPI.Catalog.Domain.Entities;
using CatalogAPI.Catalog.Application.Products.Dto;


namespace CatalogAPI.Catalog.Application.Products.Handlers
{
    public class CreateProductUseCase
    {
        private readonly IProductsRepository _productRepository;

        public CreateProductUseCase(IProductsRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Guid> Execute(CreateProductDto input)
        {
            try 
            {
                var product = new Product(
                    input.Name,
                    input.Price,
                    input.Description
                );
                await _productRepository.CreateOne(product);
                return product.Id;
            }
            catch (Exception ex)
            {
                throw new Exception("Error creating product", ex);
            }

        }
    }
}
