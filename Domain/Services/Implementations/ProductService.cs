using Microsoft.Extensions.Logging;
using Shopbridge_base.Data.Repository;
using Shopbridge_base.Domain.Models;
using Shopbridge_base.Domain.Services.Interfaces;
using Shopbridge_base.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopbridge_base.Domain.Services
{
    public class ProductService : IProductService
    {
        private readonly ILogger<ProductService> _logger;
        private IProductRepository _productRepository;

        public ProductService (IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Product> CreateProduct(ProductVM productVM)
        {
            var product = Product.CreatedProduct(productVM);
            product= await _productRepository.AddProduct(product);
            return product;

        }

        public async Task<Product> GetProduct(int product_Id)
        {

            return  await _productRepository.GetProduct(product_Id);

        }

        public async Task<List<Product>> GetAllProduct()
        {
            return await _productRepository.GetAllProduct();
        }

        public async Task<bool> DeleteProduct(int product_Id)
        {
             await _productRepository.DeleteProduct(product_Id);
            return true;
        }

        public async Task<Product> UpdateProduct(int product_Id, Product product)
        {          
            var updatedProduct= await _productRepository.UpdateProduct(product_Id, product);
            return updatedProduct;
        }
    }
}
