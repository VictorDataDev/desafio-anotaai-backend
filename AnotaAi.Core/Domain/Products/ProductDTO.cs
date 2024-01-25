using AnotaAi.Core.Domain.Categorys;

namespace AnotaAi.Core.Domain.Products
{
    public record ProductDTO
    {
        public Guid? Id { get;  set; }
        public string? Title { get;  set; }
        public Guid Owner { get;  set; }
        public Category Category { get;  set; }
        public decimal Price { get;  set; }
        public string? Description { get;  set; }
    }
}
