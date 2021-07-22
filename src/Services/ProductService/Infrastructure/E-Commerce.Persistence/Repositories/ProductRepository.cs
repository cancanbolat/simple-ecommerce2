using AutoMapper;
using AutoMapper.QueryableExtensions;
using E_Commerce.Application.DTOs;
using E_Commerce.Application.Interfaces;
using E_Commerce.Domain.Entities;
using E_Commerce.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Sluggy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Persistence.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private readonly ECommerceDbContext context;

        public ProductRepository(ECommerceDbContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<int> AddProduct(Product product)
        {
            var newProduct = new Product
            {
                Id = product.Id,
                Title = product.Title,
                Image = product.Image,
                Description = product.Description,
                IsDeleted = false,
                Number = DateTime.UtcNow.ToFileTime().ToString(),
                Slug = product.Title.ToSlug(),
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow,
            };
            await context.Products.AddAsync(product);
            int result = await context.SaveChangesAsync();

            return result;
        }

        public async Task<ProductDetailDto> GetProductBySlug(string slug)
        {
            var query = await context.Products
                .Include(x => x.ProductPrice).ThenInclude(y => y.Edition)
                .Include(x => x.ProductCategories).ThenInclude(y => y.Category)
                .Where(p => p.Slug == slug)
                .Select(z => new ProductDetailDto
                {
                    Id = z.Id,
                    Number = z.Number,
                    Title = z.Title,
                    Description = z.Description,
                    Image = z.Image,
                    Category = z.ProductCategories.Select(x => x.Category.Title).FirstOrDefault(),
                    CategorySlug = z.ProductCategories.Select(x => x.Category.Slug).FirstOrDefault(),
                    Price = z.ProductPrice.Select(x => x.Price).Min(),
                    Prices = z.ProductPrice
                    .Select(x => new ProductPriceDto
                    {
                        EditionId = x.EditionId,
                        Edition = x.Edition,
                        Price = x.Price
                    }).ToList()
                })
                .FirstOrDefaultAsync();

            return query;
        }

        public async Task<List<ProductDto>> GetProducts()
        {
            var query = await context.Products
                .Include(x => x.ProductPrice).ThenInclude(y => y.Edition)
                .Select(z => new ProductDto
                {
                    Id = z.Id,
                    Title = z.Title,
                    Image = z.Image,
                    Slug = z.Slug,
                    Price = z.ProductPrice.Select(x => x.Price).Min(),
                })
                .ToListAsync();

            return query;
        }
    }
}
