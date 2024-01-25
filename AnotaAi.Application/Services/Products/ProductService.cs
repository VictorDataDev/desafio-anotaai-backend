using AnotaAi.Application.IServices;
using AnotaAi.Core.Domain.Products;
using AnotaAi.Core.Interfaces;

namespace AnotaAi.Application.Services.Products
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Product Add(ProductDTO product)
        {
           return _productRepository.Add(new Product().ToNewEntity(product));
        }

        public void Delete(Guid productId)
        {
            _productRepository.Delete(productId);
        }

        public List<Product> GetAll()
        {
            return _productRepository.GetAll();
        }

        public Product Update(ProductDTO product)
        {
            //var productInDb = _productRepository.GetById(product.Id);

            //if(!(productInDb is null))
            //    _productRepository.Update()
            return new Product();
        }
    }
}
