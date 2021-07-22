using AutoMapper;
using E_Commerce.Application.DTOs;
using E_Commerce.Application.Features.Commands.Cart;
using E_Commerce.Application.Features.Queries.Cart;
using E_Commerce.Domain.Entities;
using Sluggy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region Product Mapping
            // Products
            CreateMap<Product, ProductDto>()
                .ForMember(x => x.Price, y => y.MapFrom(z => z.ProductPrice.Select(x => x.Price)));

            // Product details
            CreateMap<Product, ProductDetailDto>().ReverseMap();
            #endregion

            #region Category Mapping
            CreateMap<Category, CategoryDto>().ReverseMap();
            #endregion

            #region Card mapping
            CreateMap<CartItem, CartItemDto>().ReverseMap();
            CreateMap<CartItem, GetAllCartItemQuery>().ReverseMap();
            CreateMap<CartItem, UpdateCartCommand>().ReverseMap();
            CreateMap<CartItem, DeleteCartCommand>().ReverseMap();
            CreateMap<CartItem, AddCartCommand>().ReverseMap();
            #endregion

            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Edition, EditionDto>().ReverseMap();
        }
    }
}
