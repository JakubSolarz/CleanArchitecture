using BlazorHero.CleanArchitecture.Application.Extensions;
using BlazorHero.CleanArchitecture.Application.Interfaces.Repositories;
using BlazorHero.CleanArchitecture.Application.Specifications.Ecommerce;
using BlazorHero.CleanArchitecture.Domain.Entities.Catalog;
using BlazorHero.CleanArchitecture.Shared.Wrapper;
using MediatR;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace BlazorHero.CleanArchitecture.Application.Features.Products.Queries.Ecommerce
{
    public class GetProductsQuery : IRequest<Result<List<GetProductsResponse>>>
    {
        public int? BrandId { get; set; }

        public GetProductsQuery(int? brandId)
        {
            BrandId = brandId;
        }
    }

    internal class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, Result<List<GetProductsResponse>>>
    {
        private readonly IUnitOfWork<int> _unitOfWork;

        public GetProductsQueryHandler(IUnitOfWork<int> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<List<GetProductsResponse>>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            Expression<Func<Product, GetProductsResponse>> expression = e => new GetProductsResponse
            {
                Id = e.Id,
                Name = e.Name,
                Description = e.Description,
                Rate = e.Rate,
                Barcode = e.Barcode,
                Brand = e.Brand.Name,
                BrandId = e.BrandId,
                ImageDataURL = e.ImageDataURL
            };
            var productFilterSpec = new ProductByBrandIdSpecification(request.BrandId);

            return await Result<List<GetProductsResponse>>.SuccessAsync(_unitOfWork.Repository<Product>().Entities
               .Specify(productFilterSpec)
               .Select(expression)
               .ToList());
        }
    }
}