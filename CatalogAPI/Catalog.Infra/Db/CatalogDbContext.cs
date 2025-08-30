using Microsoft.EntityFrameworkCore;
using CatalogAPI.Catalog.Domain.Entities;
using CatalogAPI.Catalog.Domain.Interfaces;
using System.Reflection.Metadata.Ecma335;

namespace CatalogAPI.Catalog.Infra.Db
{
    // Essa classe é responsável por configurar o contexto do banco de dados
    // Ela herda da classe DbContext do Entity Framework Core
    public class CatalogDbContext : DbContext, IDb
    {
        // Essa propriedade é responsável por mapear a tabela de produtos
        public DbSet<Product> Products { get; set; }
    
        public string DbPath { get; }
 
        // Essa é a construtor da classe CatalogDbContext
        // Ele é responsável por configurar o caminho do banco de dados
        // Nesse caso, eu estou usando o SQLite como banco de dados
        public CatalogDbContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "catalog.db");
        }
    
        // Essa é a função que configura o banco de dados
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite($"Data Source={DbPath}");
        }

        public async Task<T> Insert<T>(T entity) where T: class
        {
            if(entity is null) throw new ArgumentNullException(nameof(entity), "Entity must be set");
            
            this.Add(entity);
            await this.SaveChangesAsync();

            return entity;
        }

        public async Task<T> GetOneByID<T>(Guid id) where T: class
        {
            if(id == Guid.Empty) throw new ArgumentException("ID must be set", nameof(id));

            var dbSet = this.Set<T>();

            var res = await dbSet.FirstOrDefaultAsync(e => 
            (Guid)e.GetType().GetProperty("Id")!.GetValue(e)! == id) ?? 
                throw new KeyNotFoundException($"Entity of type {typeof(T).Name} with ID {id} not found");

            return res;
        }

        public async Task<T> UpdateEntity<T>(T entity) where T : class
        {
            if (entity is null) 
                throw new ArgumentNullException(nameof(entity), "Entity must be set");

            this.Set<T>().Update(entity);
            await this.SaveChangesAsync();

            return entity;
        }

        public async Task<IEnumerable<T>> GetAll<T>() where T : class
        {
            return await this.Set<T>().ToListAsync();
        }

        public async Task Delete<T>(T entity) where T : class
        {
            if (entity is null) 
                throw new ArgumentNullException(nameof(entity), "Entity must be set");

            this.Set<T>().Remove(entity);
            await this.SaveChangesAsync();
        }
    }
}