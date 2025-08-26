using CatalogAPI.Catalog.Domain.Interfaces;
using MediatR;

namespace CatalogAPI.Catalog.Application.Products.Handlers
{
    public class DeleteProductUseCase
    {
        private readonly IProductsRepository _productsRepository;

        public DeleteProductUseCase(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        public async Task<Unit> Execute(Guid productId)
        {
            await _productsRepository.Delete(productId);

            return Unit.Value;
        }
    }
}
