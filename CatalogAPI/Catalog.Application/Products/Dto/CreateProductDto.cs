namespace CatalogAPI.Catalog.Application.Products.Dto
{
    public class CreateProductDto
    {
        public required string Name { get; set; }
        public required decimal Price { get; set; }
        public string? Description { get; set; }
    }
}