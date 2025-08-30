using CatalogAPI.Catalog.Domain.Entities;
using CatalogAPI.Catalog.Domain.Interfaces;

namespace CatalogAPI.Catalog.Infra.Repositories;

public class ProdutcsRepository : IProductsRepository
{
    private readonly IDb _db;

    public ProdutcsRepository(IDb db)
    {
        _db = db;
    }

    public async Task<Guid> CreateOne(Product product)
    {
        if (product == null) 
            throw new ArgumentNullException(nameof(product));

        var result = await _db.Insert(product);
        return result.Id;
    }

    public async Task Delete(Guid id)
    {
        var product = await _db.GetOneByID<Product>(id);
        await _db.Delete(product);
    }

    public async Task<IEnumerable<Product>> GetAll()
    {
        return await _db.GetAll<Product>();
    }

    public async Task<Product?> GetOneByID(Guid id)
    {
        try
        {
            return await _db.GetOneByID<Product>(id);
        }
        catch (KeyNotFoundException)
        {
            return null;
        }
    }

    public async Task<Product> Update(Product product)
    {
        if (product == null) 
            throw new ArgumentNullException(nameof(product));

            return await _db.UpdateEntity(product);
    }
}
