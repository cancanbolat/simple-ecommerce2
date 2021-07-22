using AutoMapper;
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

namespace E_Commerce.Application.Features.Commands.Cart
{
    public class UpdateCartCommand : IRequest<ServiceResponse<int>>
    {
        public int Id { get; set; }
        public int QuantityActionType { get; set; }

        public class AddCartCommandHandler : IRequestHandler<UpdateCartCommand, ServiceResponse<int>>
        {
            private readonly ICartRepository cartRepository;
            private readonly IMapper mapper;

            public AddCartCommandHandler(ICartRepository cartRepository, IMapper mapper)
            {
                this.cartRepository = cartRepository;
                this.mapper = mapper;
            }

            public async Task<ServiceResponse<int>> Handle(UpdateCartCommand request, CancellationToken cancellationToken)
            {
                var cardItemDb = await cartRepository.UpdateQuantity(request.Id, request.QuantityActionType);
                var cardRequest = mapper.Map<CartItem>(cardItemDb);

                return new ServiceResponse<int>
                {
                    Value = cardRequest.Quantity,
                    Message = "Updated successfuly"
                };
            }
        }
    }
}
