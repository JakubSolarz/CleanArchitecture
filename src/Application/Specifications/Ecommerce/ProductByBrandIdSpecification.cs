using BlazorHero.CleanArchitecture.Application.Specifications.Base;
using BlazorHero.CleanArchitecture.Domain.Entities.Catalog;

namespace BlazorHero.CleanArchitecture.Application.Specifications.Ecommerce
{
    public class ProductByBrandIdSpecification : HeroSpecification<Product>
    {
        public ProductByBrandIdSpecification(int? brandId)
        {
            Includes.Add(a => a.Brand);
            if (brandId.HasValue)
            {
                Criteria = p => p.Barcode != null && (p.BrandId == brandId.Value);
            }
            else
            {
                Criteria = p => p.Barcode != null;
            }
        }
    }
}