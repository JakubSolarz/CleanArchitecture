using Microsoft.AspNetCore.Components;
using MudBlazor;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BlazorHero.CleanArchitecture.Client.Infrastructure.Managers.Ecommerce;
using BlazorHero.CleanArchitecture.Application.Features.Products.Queries.Ecommerce;

namespace BlazorHero.CleanArchitecture.Client.Pages.Ecommerce
{
    public partial class Products
    {
        [Parameter] public int Id { get; set; }
        [Parameter] public string Title { get; set; }
        [Inject] private IEcommerceManager ecommerceManager { get; set; }

        private List<GetProductsResponse> _productList = new();

        private ClaimsPrincipal _currentUser;
        private bool _loaded;

        protected override async Task OnInitializedAsync()
        {
            _currentUser = await _authenticationManager.CurrentUser();

            await GetProductsAsync();
            _loaded = true;
        }

        private async Task GetProductsAsync()
        {
            var response = await ecommerceManager.GetProductsAsync(Id);
            if (response.Succeeded)
            {
                _productList = response.Data.ToList();
            }
            else
            {
                foreach (var message in response.Messages)
                {
                    _snackBar.Add(message, Severity.Error);
                }
            }
        }
    }
}