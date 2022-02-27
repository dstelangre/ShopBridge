using Microsoft.EntityFrameworkCore;
using Shopbridge_base.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Shopbridge_base.Data.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly Shopbridge_Context dbcontext;

        public ProductRepository(Shopbridge_Context _dbcontext )
        {
            this.dbcontext = _dbcontext;
        }

        public async Task<Product> AddProduct(Product product)
        {
            await dbcontext.Product.AddAsync(product);
            await dbcontext.SaveChangesAsync();

            return product;
        }

        public async Task<Product> GetProduct(int product_Id)
        {

            if (IsProductExists(product_Id))
            {
                return await dbcontext.Product.Where(p => p.Product_Id == product_Id).FirstOrDefaultAsync();
            }
            else
            {
                throw new ValidationException("product not found");
            }
          

        }

        public async Task<List<Product>>  GetAllProduct()
        {
            var products = await  dbcontext.Product.ToListAsync();
            return products;
        }

        public async Task<bool> DeleteProduct(int product_Id)
        {          
            if (IsProductExists(product_Id))
            {
                var product = dbcontext.Product.Where(p => p.Product_Id == product_Id).FirstOrDefault();
                dbcontext.Product.Remove(product);
                await  dbcontext.SaveChangesAsync();
                return true;
            }
            else
            {
                throw new ValidationException("product not found");
            }
        }

        public async Task<Product> UpdateProduct(int product_Id, Product product)
        {
            if (IsProductExists(product_Id))
            {
                Product existingProduct = GetProduct(product_Id).Result;
                existingProduct.UpdateProduct(product);                   
                await dbcontext.SaveChangesAsync();
                return existingProduct;
            }
            else
            {
                throw new ValidationException("product not found");
            }
        }


        private bool IsProductExists(int product_Id)
        {
            var product = dbcontext.Product.Where(p => p.Product_Id == product_Id).FirstOrDefault();
            if (product != null) return true;
            return false;
        }
    }
}
