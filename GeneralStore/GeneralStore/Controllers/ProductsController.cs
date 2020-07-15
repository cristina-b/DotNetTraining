using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using GeneralStore.Data;
using GeneralStore.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GeneralStore.Controllers
{    
    [Route("api/products")]
    /*[Route("api/auth")]*/
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ApiDbContext context;
        const string ETAG_HEADER = "ETag";
        const string MATCH_HEADER = "If-Match";

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
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState.ValidationState);
            }

            if (id < 0)
            {
                throw new ArgumentException("not a valid product id");
            }

            if (!this.ProductExists(id))
            {
                return this.NotFound();
            }

            var dbTag = GetHash(product);
            if (!HttpContext.Request.Headers.ContainsKey(MATCH_HEADER) ||
                !HttpContext.Request.Headers[MATCH_HEADER].Contains(dbTag))
            {
                return new StatusCodeResult(412);
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
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState.ValidationState);
            }

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

        public static string GetHash(Product product)
        {
            if (product == null)
            {
                return string.Empty;
            }
            var itemText = $"{product.Id}|{product.Name}";
            using (var md5 = MD5.Create())
            {
                byte[] retVal = md5.ComputeHash(Encoding.Unicode.GetBytes(itemText));
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < retVal.Length; i++)
                {
                    sb.Append(retVal[i].ToString("x2"));
                }
                return sb.ToString();
            }
        }
    }
}
