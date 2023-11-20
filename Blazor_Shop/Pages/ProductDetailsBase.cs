using Blazor_Shop.Services.Interface;
using Microsoft.AspNetCore.Components;
using ShopDTOModels.Dtos;

namespace Blazor_Shop.Pages
{
    public class ProductDetailsBase : ComponentBase
    {
        [Parameter]
        public int Id { get; set; }
        [Inject]
        public IProductService ProductService { get; set; }
        public ProductDto Product { get; set; }
        public string ErrorMEssage { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                Product = await ProductService.GetItem(Id);

            }
            catch (Exception ex)
            {

                ErrorMEssage = ex.Message;
            }
        }

    }
}

    
