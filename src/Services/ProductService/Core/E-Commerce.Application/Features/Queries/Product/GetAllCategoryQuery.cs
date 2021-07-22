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
    public class GetAllCategoryQuery : IRequest<ServiceResponse<List<CategoryDto>>>
    {
        public class GetAllCategoryQueryHandler : IRequestHandler<GetAllCategoryQuery, ServiceResponse<List<CategoryDto>>>
        {
            private readonly ICategoryRepository categoryRepository;
            private readonly IMapper mapper;

            public GetAllCategoryQueryHandler(ICategoryRepository categoryRepository, IMapper mapper)
            {
                this.categoryRepository = categoryRepository;
                this.mapper = mapper;
            }

            public async Task<ServiceResponse<List<CategoryDto>>> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
            {
                var categories = await categoryRepository.GetAll();
                var result = mapper.Map<List<CategoryDto>>(categories);

                return new ServiceResponse<List<CategoryDto>>
                {
                    Value = result,
                    Message = $"Category Count: {result.Count()}"
                };
            }
        }
    }
}
