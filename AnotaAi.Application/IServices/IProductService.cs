using AnotaAi.Core.Domain.Products;

namespace AnotaAi.Application.IServices
{
    public interface IProductService
    {
        Product Add(ProductDTO product);
        Product Update(ProductDTO product);
        void Delete(Guid productId);
        List<Product> GetAll();
    }
}
