namespace BlazorHero.CleanArchitecture.Client.Infrastructure.Routes
{
    public static class EcommerceEndpoints
    {
        public static string GetAllBrands = "api/v1/Ecommerce/GetAllBrands";


        public static string GetProducts(int brandId)
        {
            return $"api/v1/Ecommerce/GetProducts/{brandId}";
        }
  }
}