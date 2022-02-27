using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Shopbridge_base.Domain.Models;
using Shopbridge_base.Domain.Services.Interfaces;
using Shopbridge_base.ViewModels;

namespace Shopbridge_base.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService productService;
        private readonly ILogger<ProductsController> logger;
        public ProductsController(IProductService _productService)
        {
            this.productService = _productService;
        }

       
        [HttpGet]   
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            try
            {
                var products = await productService.GetAllProduct();
                return Ok(products);
            }
            catch(Exception ex)
            {
                return Ok(ex.Message);
            }
           
        }

        
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            try
            {
                var product = await productService.GetProduct(id);
                return Ok(product);
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }

       
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Product product)
        {
            try
            {
                var updatedProduct = await productService.UpdateProduct(id, product);
                return Ok(product);
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }

        
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(ProductVM productVM)
        {          
            try
            {
                var product = await productService.CreateProduct(productVM);
                return Ok(product);
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            try
            {
                await productService.DeleteProduct(id);
                return Ok(true);
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }
    }
}
