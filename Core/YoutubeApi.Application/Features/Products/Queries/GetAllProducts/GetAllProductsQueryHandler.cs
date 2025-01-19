using MediatR;
using Microsoft.EntityFrameworkCore;
using YoutubeApi.Application.DTOs;
using YoutubeApi.Application.Interfaces.AutoMapper;
using YoutubeApi.Application.Interfaces.UnitOfWorks;
using YoutubeApi.Domain.Entities;


namespace YoutubeApi.Application.Features.Products.Queries.GetAllProducts
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQueryRequest, IList<GetAllProductsQueryResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapperr _mapperr;
        public GetAllProductsQueryHandler(IUnitOfWork unitOfWork, IMapperr mapperr)
        {
            _unitOfWork = unitOfWork;
            _mapperr = mapperr;
        }


        public async Task<IList<GetAllProductsQueryResponse>> Handle(GetAllProductsQueryRequest request, CancellationToken cancellationToken)
        {
            var products = await _unitOfWork.GetReadRepository<Product>().GetAllAsync(include: x => x.Include(b => b.Brand));

            var brand = _mapperr.Map<BrandDto, Brand>(new Brand());

            var map = _mapperr.Map<GetAllProductsQueryResponse, Product>(products);

            foreach (var item in map)
            {
                item.Price -= (item.Price * item.Discount / 100);
            }

            return map;
        }
    }
}