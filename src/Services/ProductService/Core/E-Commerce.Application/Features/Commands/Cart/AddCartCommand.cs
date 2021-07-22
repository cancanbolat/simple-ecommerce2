using AutoMapper;
using E_Commerce.Application.DTOs;
using E_Commerce.Application.Interfaces;
using E_Commerce.Application.Wrappers;
using E_Commerce.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace E_Commerce.Application.Features.Commands.Cart
{
    public class AddCartCommand : IRequest<ServiceResponse<int>>
    {
        public string UserId { get; set; }
        public Int16 Quantity { get; set; }
        public int EditionId { get; set; }
        public int ProductId { get; set; }

        public class AddCartCommandHandler : IRequestHandler<AddCartCommand, ServiceResponse<int>>
        {
            private readonly ICartRepository cartRepository;
            private readonly IMapper mapper;

            public AddCartCommandHandler(ICartRepository cartRepository, IMapper mapper)
            {
                this.cartRepository = cartRepository;
                this.mapper = mapper;
            }

            public async Task<ServiceResponse<int>> Handle(AddCartCommand request, CancellationToken cancellationToken)
            {
                var cartItem = mapper.Map<CartItem>(request);
                await cartRepository.AddToCart(cartItem);

                return new ServiceResponse<int>
                {
                    Value = cartItem.ProductId,
                    Message = $"Added successfuly."
                };
            }
        }
    }
}
