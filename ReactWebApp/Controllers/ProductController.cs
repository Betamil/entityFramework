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
                    product.Supplier = await _databaseContext.Suppliers.FindAsync(product.Supplier);
                }
            }
            return Ok(await _databaseContext.Categories.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<Category>> AddProduct(Category category)
        {
            _databaseContext.Categories.Add(category);
            await _databaseContext.SaveChangesAsync();
            return Ok(category);
        }
    }
}

