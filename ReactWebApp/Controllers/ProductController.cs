using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReactWebApp.Entity.Conf;
using ReactWebApp.Entity.Models;

namespace ReactWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {

        private readonly DatabaseContext _databaseContext;

        public ProductController(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProduct()
        {
            var products = await _databaseContext.Products.ToListAsync();
            foreach (var product in products)
            {
                if(product != null)
                {
                    product.Supplier = await _databaseContext.Suppliers.FindAsync(product.SupplierId);
                    product.Category = await _databaseContext.Categories.FindAsync(product.CategoryId);
                }
            }
            return Ok(await _databaseContext.Products.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<Category>> AddProduct(Product product)
        {
            _databaseContext.Products.Add(product);
            await _databaseContext.SaveChangesAsync();
            return Ok(product);
        }
    }
}

