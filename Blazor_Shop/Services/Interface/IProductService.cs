using ShopDTOModels.Dtos;

namespace Blazor_Shop.Services.Interface
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetItems();
        Task<ProductDto> GetItem(int id);
    }
}
