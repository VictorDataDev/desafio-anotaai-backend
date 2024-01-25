using AnotaAi.Core.Domain.Categorys;

namespace AnotaAi.Core.Interfaces
{
    public interface ICategoryRepository
    {
        Category Add(Category category);
        Category Update(Category category);
        void Delete(Guid categorytId);
        List<Category> GetAll();
    }
}
