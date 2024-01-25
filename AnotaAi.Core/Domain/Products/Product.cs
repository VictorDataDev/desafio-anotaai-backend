using AnotaAi.Core.Domain.Categorys;
using MongoDB.Bson.Serialization.Attributes;
using System.Diagnostics;

namespace AnotaAi.Core.Domain.Products
{
    public class Product
    {
        [BsonId]
        public Guid Id { get; private set; }
        public string? Title { get; private set; }
        public Guid Owner { get; private set; }
        public Category Category { get; private set; }
        public int Price { get; private set; }
        public string? Description { get; private set; }

        public Product()
        {
        }

        public Product(string title, Guid owner, Category category, decimal price, string description)
        {
            this.Title = title;
            this.Owner = owner;
            this.Category = category;
            this.Price = (int)price * 100;
            this.Description = description;
        }

        public void SetId()
        {
            this.Id = Guid.NewGuid();
        }

        public Product ToNewEntity(ProductDTO data)
        {
            SetId();
            this.Title = data.Title;
            this.Owner = data.Owner;
            this.Category = data.Category;
            this.Price = (int)data.Price * 100;
            this.Description = data.Description;

            return this;
        }

        public Product ToEntity(Guid id,ProductDTO data)
        {
            this.Id = id;
            this.Title = data.Title;
            this.Owner = data.Owner;
            this.Category = data.Category;
            this.Price = (int)data.Price * 100;
            this.Description = data.Description;

            return this;
        }
    }
}
