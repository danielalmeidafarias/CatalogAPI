using CatalogAPI.Catalog.Domain.Entities;
using CatalogAPI.Catalog.Domain.Interfaces;

namespace CatalogAPI.Catalog.Infra.Repositories;

public class ProdutcsRepository : IProductsRepository
{

    public IDb _db;

    public ProdutcsRepository(IDb db) {
        _db = db;
    }
    public Task<Guid> CreateOne(Product product)
    {
        throw new NotImplementedException();
    }

    public Task Delete(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Product>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<Product?> GetOneByID(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<Product> Update(Product product)
    {
        throw new NotImplementedException();
    }
}