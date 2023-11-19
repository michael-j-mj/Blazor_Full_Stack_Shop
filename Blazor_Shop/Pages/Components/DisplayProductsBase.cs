using Microsoft.AspNetCore.Components;
using ShopDTOModels.Dtos;

namespace Blazor_Shop.Pages.Components
{
    public class DisplayProductsBase:ComponentBase 
    {
        [Parameter]
        public IEnumerable<ProductDto> Products { get; set; }

    }
}
