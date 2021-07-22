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

namespace E_Commerce.Application.Features.Queries.Cart
{
    public class GetAllCartItemQuery : IRequest<ServiceResponse<List<CartItemDto>>>
    {
        public string UserId { get; set; }
        public class GetAllCardItemQueryHandler : IRequestHandler<GetAllCartItemQuery, ServiceResponse<List<CartItemDto>>>
        {
            private readonly ICartRepository cartRepository;
            private readonly IMapper mapper;

            public GetAllCardItemQueryHandler(ICartRepository cartRepository, IMapper mapper)
            {
                this.cartRepository = cartRepository;
                this.mapper = mapper;
            }

            public async Task<ServiceResponse<List<CartItemDto>>> Handle(GetAllCartItemQuery request, CancellationToken cancellationToken)
            {
                var cartItems = await cartRepository.GetCardItems(request.UserId);
                var result = mapper.Map<List<CartItemDto>>(cartItems);

                return new ServiceResponse<List<CartItemDto>>
                {
                    Value = result
                };
            }
        }
    }
}
