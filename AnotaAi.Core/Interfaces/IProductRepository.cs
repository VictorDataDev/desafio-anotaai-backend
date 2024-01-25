using AnotaAi.Core.Domain.Products;

namespace AnotaAi.Core.Interfaces
{
    public interface IProductRepository
    {
        Product Add(Product product);
        Product Update(Product product);
        void Delete(Guid productId);
        List<Product> GetAll();

    }
}
