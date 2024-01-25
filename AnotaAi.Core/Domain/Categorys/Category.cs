using MongoDB.Bson.Serialization.Attributes;

namespace AnotaAi.Core.Domain.Categorys
{
    public class Category
    {
        [BsonId]
        public Guid Id { get; private set; }
        public string? Title { get; private set; }
        public Guid Owner { get; private set; }
        public string? Description { get; private set; }

        public Category(string title, Guid owner, string description)
        {
            this.Title = title;
            this.Owner = owner;
            this.Description = description;
        }
        public void SetId()
        {
            this.Id = Guid.NewGuid();   
        }
    }
}
