namespace CatalogAPI.Catalog.Domain.Interfaces
{
    public interface IProductsRepository
    {
        Task<Guid> CreateOne(Entities.Product product);
        Task<Entities.Product?> GetOneByID(Guid id);
        Task<IEnumerable<Entities.Product>> GetAll();
        Task<Entities.Product> Update(Entities.Product product);
        Task Delete(Guid id);
    }

}
