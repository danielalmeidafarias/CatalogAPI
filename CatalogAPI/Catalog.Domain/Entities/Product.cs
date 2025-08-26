namespace CatalogAPI.Catalog.Domain.Entities
{
    // Aqui eu estou definindo a entidade Product
    // ELa define o domínio de produtos no meu sistema, com propriedades e comportamentos relacionados a produtos
    public class Product
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public string Name { get; set; }

        public decimal Price { get; set; }

        public string? Description { get; set; }

        private Product() { }

        public Product(string name, decimal price, string? description)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Product name cannot be empty.", nameof(name));
            if (price < 0)
                throw new ArgumentOutOfRangeException(nameof(price), "Price cannot be negative.");

            Name = name;
            Price = price;
            Description = description;
        }

        public void Update(string? name, decimal? price, string? description)
        {
            if (name is not null)
            {
                if (string.IsNullOrWhiteSpace(name))
                    throw new ArgumentException("Product name cannot be empty.", nameof(name));
                Name = name;
            }

            if (price is not null)
            {
                if (price < 0)
                    throw new ArgumentOutOfRangeException(nameof(price), "Price cannot be negative.");
                Price = price.Value;
            }
        
            if (description is not null)
            {
                Description = description;
            }
        }

    }
}
