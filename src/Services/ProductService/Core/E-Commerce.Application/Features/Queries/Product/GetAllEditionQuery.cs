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
    public class GetAllEditionQuery : IRequest<ServiceResponse<List<EditionDto>>>
    {
        public class GetAllEditionQueryHandler : IRequestHandler<GetAllEditionQuery, ServiceResponse<List<EditionDto>>>
        {
            private readonly IEditionRepository editionRepository;
            private readonly IMapper mapper;

            public GetAllEditionQueryHandler(IEditionRepository editionRepository, IMapper mapper)
            {
                this.editionRepository = editionRepository;
                this.mapper = mapper;
            }
            public async Task<ServiceResponse<List<EditionDto>>> Handle(GetAllEditionQuery request, CancellationToken cancellationToken)
            {
                var editions = await editionRepository.GetAll();
                var result = mapper.Map<List<EditionDto>>(editions);

                return new ServiceResponse<List<EditionDto>>
                {
                    Value = result
                };
            }
        }
    }
}
