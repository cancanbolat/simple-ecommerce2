using AutoMapper;
using E_Commerce.Application.DTOs;
using E_Commerce.Application.Interfaces;
using E_Commerce.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace E_Commerce.Application.Features.Queries.Product
{
    public class GetProductQuery : IRequest<ServiceResponse<ProductDetailDto>>
    {
        public string Slug { get; set; }

        public class GetProductQueryHandler : IRequestHandler<GetProductQuery, ServiceResponse<ProductDetailDto>>
        {
            private readonly IProductRepository productRepository;
            private readonly IMapper mapper;

            public GetProductQueryHandler(IProductRepository productRepository, IMapper mapper)
            {
                this.productRepository = productRepository;
                this.mapper = mapper;
            }

            public async Task<ServiceResponse<ProductDetailDto>> Handle(GetProductQuery request, CancellationToken cancellationToken)
            {
                var product = await productRepository.GetProductBySlug(request.Slug);
                var result = mapper.Map<ProductDetailDto>(product);

                return new ServiceResponse<ProductDetailDto>
                {
                    Value = result,
                    Message = $"Product Number: {result.Number}"
                };
            }
        }
    }
}
