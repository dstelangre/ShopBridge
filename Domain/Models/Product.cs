using Shopbridge_base.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shopbridge_base.Domain.Models
{
    public class Product 
    {
        [Key]
        public int Product_Id { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }


        public static Product CreatedProduct(ProductVM productVM)
        {
           return  new Product{ 
                ProductName=productVM.ProductName,
                Description= productVM.Description,
                Price=productVM.Price,
               CreatedOn = DateTime.UtcNow,
               UpdatedOn = DateTime.UtcNow
           };
        }

        public void UpdateProduct(Product product)
        {
            ProductName = product.ProductName;
            Description = product.Description;
            Price = product.Price;
            UpdatedOn = DateTime.UtcNow;
        }
    }
}
