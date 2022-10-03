using BlazorHero.CleanArchitecture.Application.Features.Brands.Queries.GetAll;
using BlazorHero.CleanArchitecture.Application.Features.Products.Queries.Ecommerce;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BlazorHero.CleanArchitecture.Server.Controllers.v1.Order
{
    public class EcommerceController : BaseApiController<EcommerceController>
    {

        /// <summary>
        /// Get All Brands
        /// </summary>
        /// <returns>Status 200 OK</returns>
        public async Task<IActionResult> GetAllBrands()
        {
            var brands = await _mediator.Send(new GetAllBrandsQuery());
            return Ok(brands);
        }

        /// <summary>
        /// Get All Products
        /// </summary>
        /// <param name="brandId"></param>
        /// <returns>Status 200 OK</returns>
        [HttpGet]
        public async Task<IActionResult> GetProducts(int? brandId)
        {
            var products = await _mediator.Send(new GetProductsQuery(brandId));
            return Ok(products);
        }
    }
}