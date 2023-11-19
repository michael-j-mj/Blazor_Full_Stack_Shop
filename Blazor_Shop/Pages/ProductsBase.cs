using Blazor_Shop.Services.Interface;
using Microsoft.AspNetCore.Components;
using ShopDTOModels.Dtos;
using System.Text.RegularExpressions;

namespace Blazor_Shop.Pages
{
    public class ProductsBase : ComponentBase
    {
        [Inject]
        public IProductService ProductService { get; set; }

        public IEnumerable<ProductDto> Products { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Products = await ProductService.GetItems();

        }
        protected IOrderedEnumerable<IGrouping<int, ProductDto>> GetGroupByCategory()
        {
            return Products
    .GroupBy(product => product.CategoryId)
    .OrderBy(group => group.Key);
        }
        protected string GetCategoryName(IGrouping<int, ProductDto> group)
        {
            return group.FirstOrDefault(pg => pg.CategoryId == group.Key).CategoryName;
        }
    }
}
