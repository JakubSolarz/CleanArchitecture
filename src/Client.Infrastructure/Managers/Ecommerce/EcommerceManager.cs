using BlazorHero.CleanArchitecture.Application.Features.Brands.Queries.GetAll;
using BlazorHero.CleanArchitecture.Client.Infrastructure.Extensions;
using BlazorHero.CleanArchitecture.Shared.Wrapper;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using BlazorHero.CleanArchitecture.Application.Features.Products.Queries.Ecommerce;

namespace BlazorHero.CleanArchitecture.Client.Infrastructure.Managers.Ecommerce
{
    public class EcommerceManager : IEcommerceManager
    {
        private readonly HttpClient _httpClient;

        public EcommerceManager(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IResult<List<GetAllBrandsResponse>>> GetAllBrandsAsync()
        {
            var response = await _httpClient.GetAsync(Routes.EcommerceEndpoints.GetAllBrands);
            return await response.ToResult<List<GetAllBrandsResponse>>();
        }
        public async Task<IResult<List<GetProductsResponse>>> GetProductsAsync(int brandId)
        {
            var response = await _httpClient.GetAsync(Routes.EcommerceEndpoints.GetProducts(brandId));
            return await response.ToResult<List<GetProductsResponse>>();
        }
    }
}