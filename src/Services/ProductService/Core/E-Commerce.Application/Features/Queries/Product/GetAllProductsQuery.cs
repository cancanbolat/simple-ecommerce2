using AutoMapper;
using E_Commerce.Application.DTOs;
using E_Commerce.Application.Interfaces;
using E_Commerce.Application.Wrappers;
using E_Commerce.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace E_Commerce.Application.Features.Queries.Product
{
    public class GetAllProductsQuery : IRequest<ServiceResponse<List<ProductDto>>>
    {
        public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, ServiceResponse<List<ProductDto>>>
        {
            private readonly IProductRepository productRepository;
            private readonly IMapper mapper;

            public GetAllProductsQueryHandler(IProductRepository productRepository, IMapper mapper)
            {
                this.productRepository = productRepository;
                this.mapper = mapper;
            }

            public async Task<ServiceResponse<List<ProductDto>>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
            {
                var products = await productRepository.GetProducts();
                var result = mapper.Map<List<ProductDto>>(products);

                return new ServiceResponse<List<ProductDto>>
                {
                    Value = result,
                    Message = $"Product list. Total product: {result.Count()}"
                };
            }
        }

    }
}
