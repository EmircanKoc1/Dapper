using DapperAPI.DTOs;
using DapperAPI.Entities;

namespace DapperAPI.Interfaces
{
    public interface IProductRepository
    {


        public IEnumerable<Product> GetProducts();
        public Product GetProductById(int productId);
        public void CreateProduct(ProductDTO product);
    }
}
