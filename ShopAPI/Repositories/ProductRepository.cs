using Microsoft.EntityFrameworkCore;
using ShopAPI.Data;
using ShopAPI.Models;
using ShopAPI.Repositories.Contracts;

namespace ShopAPI.Repositories
{
    public class ProductRepository:IProductRepositories
    {
        private readonly ShopDbContext _context;
        public ProductRepository(ShopDbContext context) {
            _context = context;

        }

       public async Task<IEnumerable<Product>> GetItems() {
            return await _context.Products.ToListAsync();
        }
       public async Task<IEnumerable<ProductCategory>> GetCategories() {
            return await _context.ProductCategories.ToListAsync();
        }



       public async Task<Product> GetItem(int id)
        {
                var product = await _context.Products.FindAsync(id);
            return product;
        }

       public async Task<ProductCategory> GetCategory(int id)
        {
           var category = await _context.ProductCategories.SingleOrDefaultAsync(c => c.Id == id);
            return category; 
        }
    }
}
