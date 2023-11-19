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



        Task<Product> IProductRepositories.GetItem(int id)
        {
            throw new NotImplementedException();
        }

        Task<ProductCategory> IProductRepositories.GetCategory(int id)
        {
            throw new NotImplementedException();
        }
    }
}
