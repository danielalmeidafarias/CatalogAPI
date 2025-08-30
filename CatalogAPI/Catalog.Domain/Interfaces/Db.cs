using CatalogAPI.Catalog.Domain.Entities;

namespace CatalogAPI.Catalog.Domain.Interfaces;

public interface IDb
{
    public Task<T> Insert<T>(T entity) where T : class;
    public Task<T> GetOneByID<T>(Guid id) where T : class;
    public Task<T> UpdateEntity<T>(T entity) where T : class;
    public Task<IEnumerable<T>> GetAll<T>() where T : class;
    public Task Delete<T>(T entity) where T : class;
};