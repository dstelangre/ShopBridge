using Shopbridge_base.Domain.Models;
using Shopbridge_base.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopbridge_base.Domain.Services.Interfaces
{
    public interface IProductService
    {
        public Task<Product> CreateProduct(ProductVM productVM);
        public Task<Product> GetProduct(int product_Id);
        public Task<List<Product>> GetAllProduct();
        public Task<bool> DeleteProduct(int product_Id);
        public Task<Product> UpdateProduct(int product_Id,Product product);
    }
}
