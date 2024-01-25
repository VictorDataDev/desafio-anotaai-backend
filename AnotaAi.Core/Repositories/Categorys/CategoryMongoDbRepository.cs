using AnotaAi.Core.Domain.Categorys;
using AnotaAi.Core.Domain.Products;
using AnotaAi.Core.Interfaces;
using MongoDB.Driver;

namespace AnotaAi.Core.Repositories.Categorys
{
    public class CategoryMongoDbRepository : ICategoryRepository
    {
        private readonly IMongoCollection<Category> _collection;
        public CategoryMongoDbRepository(IMongoDatabase database)
        {
            _collection = database.GetCollection<Category>("category");
        }
        public Category Add(Category category)
        {
            category.SetId();
            _collection.InsertOne(category);
            return category;
        }

        public void Delete(Guid categorytId)
        {
            _collection.DeleteOne(c => c.Id.Equals(categorytId));
        }

        public List<Category> GetAll()
        {
            return _collection.Find(c => true).ToList();
        }

        public Category Update(Category category)
        {
            var filter = Builders<Category>.Filter.Eq(p => p.Id, category.Id);

            var update = Builders<Category>.Update
                .Set(c => c.Title, category.Title)
                .Set(c => c.Owner, category.Owner)
                .Set(c => c.Description, category.Description);

            _collection.UpdateOne(filter, update);

            return category;
        }
    }
}
