using ShopAPI.Models;

namespace ShopAPI.Repositories.Contracts
{
    public interface IProductRepositories
    {
        Task<IEnumerable<Product>> GetItems();
        Task<IEnumerable<ProductCategory>> GetCategories();

        Task<Product> GetItem(int id); 
        Task<ProductCategory> GetCategory(int id);

         
    }
}
