using AnotaAi.Core.Interfaces;
using AnotaAi.Core.Domain.Products;
using MongoDB.Driver;

namespace AnotaAi.Core.Repositories.Products
{
    public class ProductMongoDbRepository : IProductRepository
    {
        private readonly IMongoCollection<Product> _collection;
        public ProductMongoDbRepository(IMongoDatabase database)
        {
            _collection = database.GetCollection<Product>("product");
        }

        public Product Add(Product product)
        {
            _collection.InsertOne(product);
            return product;
        }

        public void Delete(Guid productId)
        {
            _collection.DeleteOne(c => c.Id.Equals(productId));
        }

        public List<Product> GetAll()
        {
            return _collection.Find(c => true).ToList();
        }

        public Product Update(Product product)
        {
            var filter = Builders<Product>.Filter.Eq(p => p.Id, product.Id);

            var update = Builders<Product>.Update
                .Set(p => p.Title, product.Title)
                .Set(p => p.Category, product.Category)
                .Set(p => p.Price, product.Price)
                .Set(p => p.Description, product.Description);

            _collection.UpdateOne(filter, update);

            return product;
        }
    }
}
