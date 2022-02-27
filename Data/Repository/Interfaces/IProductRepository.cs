using Shopbridge_base.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shopbridge_base.Data.Repository
{
    public interface IProductRepository
    {
        public Task<Product> AddProduct(Product product);
        public Task<Product> GetProduct(int product_Id);
        public Task<List<Product>> GetAllProduct();
        public Task<bool> DeleteProduct(int product_Id);
        public Task<Product> UpdateProduct(int product_Id, Product product);
    }
}
