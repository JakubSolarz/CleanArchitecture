using BlazorHero.CleanArchitecture.Application.Features.Brands.Queries.GetAll;
using BlazorHero.CleanArchitecture.Application.Features.Products.Queries.Ecommerce;
using BlazorHero.CleanArchitecture.Shared.Wrapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorHero.CleanArchitecture.Client.Infrastructure.Managers.Ecommerce
{
    public interface IEcommerceManager : IManager
    {
        Task<IResult<List<GetAllBrandsResponse>>> GetAllBrandsAsync();

        Task<IResult<List<GetProductsResponse>>> GetProductsAsync(int brandId);
    }
}