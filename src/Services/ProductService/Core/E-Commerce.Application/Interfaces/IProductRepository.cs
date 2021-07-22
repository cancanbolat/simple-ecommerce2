using E_Commerce.Application.DTOs;
using E_Commerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.Interfaces
{
    public interface IProductRepository : IMainRepository<Product, int>
    {
        Task<List<ProductDto>> GetProducts();
        Task<ProductDetailDto> GetProductBySlug(string slug);
        Task<int> AddProduct(Product product);
    }
}
