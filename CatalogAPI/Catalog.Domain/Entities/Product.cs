namespace CatalogAPI.Catalog.Domain.Entities
{
    public class Product : DbEntity
    {
        public new Guid Id { get; private set; } = Guid.NewGuid();
        public string Name { get; set; }

        public decimal Price { get; set; }

        public string? Description { get; set; }

        public Product(string name, decimal price, string? description)
        {
            Name = name;
            Price = price;
            Description = description;
        }
    }
}
