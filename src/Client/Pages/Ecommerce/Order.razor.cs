using BlazorHero.CleanArchitecture.Application.Features.Brands.Queries.GetAll;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BlazorHero.CleanArchitecture.Client.Infrastructure.Managers.Ecommerce;

namespace BlazorHero.CleanArchitecture.Client.Pages.Ecommerce
{
    public partial class Order
    {
        [Inject] private IEcommerceManager ecommerceManager { get; set; }

        private List<GetAllBrandsResponse> _brandList = new();

        private ClaimsPrincipal _currentUser;
        private bool _loaded;

        protected override async Task OnInitializedAsync()
        {
            _currentUser = await _authenticationManager.CurrentUser();

            await GetBrandsAsync();
            _loaded = true;
        }

        private async Task GetBrandsAsync()
        {
            var response = await ecommerceManager.GetAllBrandsAsync();
            if (response.Succeeded)
            {
                _brandList = response.Data.ToList();
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