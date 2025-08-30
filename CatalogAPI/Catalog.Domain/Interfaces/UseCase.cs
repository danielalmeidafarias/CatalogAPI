namespace CatalogAPI.Catalog.Domain.Interfaces
{
    public interface IUseCase<TRequest, TResponse>
    {
        Task<TResponse> Execute(TRequest input);
    }
}
