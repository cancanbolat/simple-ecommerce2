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
    public class DeleteCartCommand : IRequest<ServiceResponse<int>>
    {
        public int Id { get; set; }

        public class AddCartCommandHandler : IRequestHandler<DeleteCartCommand, ServiceResponse<int>>
        {
            private readonly ICartRepository cartRepository;
            private readonly IMapper mapper;

            public AddCartCommandHandler(ICartRepository cartRepository, IMapper mapper)
            {
                this.cartRepository = cartRepository;
                this.mapper = mapper;
            }

            public async Task<ServiceResponse<int>> Handle(DeleteCartCommand request, CancellationToken cancellationToken)
            {
                var cardItemDb = await cartRepository.GetById(request.Id);
                await cartRepository.Delete(cardItemDb.Id);

                return new ServiceResponse<int>
                {
                    Value = cardItemDb.ProductId,
                    Message = "Deleted successfuly"
                };
            }
        }
    }
}
