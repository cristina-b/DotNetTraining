using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeneralStore.Data;
using GeneralStore.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GeneralStore.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ApiDbContext context;
        public ProductsController(ApiDbContext context)
        {
            this.context = context;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            return await this.context.Products.ToListAsync();
        }

        // GET: api/Product/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await this.context.Products.FindAsync(id);

            if (product == null)
            {
                return this.NotFound();
            }

            return product;
        }

        // PUT: api/Products/2        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Product product)
        {
            if (id < 0)
            {
                throw new ArgumentException("not a valid product id");
            }

            if (!this.ProductExists(id))
            {
                return this.NotFound();
            }

            this.context.Entry(product).State = EntityState.Modified;

            try
            {
                await this.context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {


                throw;
            }

            return this.NoContent();
        }

        // POST: api/Products
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            this.context.Products.Add(product);
            await this.context.SaveChangesAsync();

            return this.CreatedAtAction("GetProduct", new { id = product.Id }, product);
        }

        // DELETE: api/Products/2
        [HttpDelete("{id}")]
        public async Task<ActionResult<Product>> DeleteProduct(int id)
        {
            var product = await this.context.Products.FindAsync(id);

            if (product == null)
            {
                return this.NotFound();
            }

            this.context.Products.Remove(product);
            await this.context.SaveChangesAsync();

            return product;
        }

        private bool ProductExists(int id)
        {
            return this.context.Products.Any(e => e.Id == id);
        }
    }
}
