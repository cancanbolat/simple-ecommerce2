using E_Commerce.Application.DTOs;
using E_Commerce.Application.Interfaces;
using E_Commerce.Domain.Entities;
using E_Commerce.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Persistence.Repositories
{
    public class CartRepository : GenericRepository<CartItem>, ICartRepository
    {
        private readonly ECommerceDbContext context;

        public CartRepository(ECommerceDbContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<CartItem> AddToCart(CartItem entity)
        {
            var cartItem = await context.CartItems.FirstOrDefaultAsync(x => x.ProductId == entity.ProductId);

            if (cartItem != null)
            {
                cartItem.Quantity++;
                context.CartItems.Attach(cartItem);
                context.Entry(cartItem).Property(x => x.Quantity).IsModified = true;
                await context.SaveChangesAsync();
            }
            else
            {
                await context.CartItems.AddAsync(entity);
                await context.SaveChangesAsync();
            }

            return entity;
        }

        public async Task<CartItem> UpdateQuantity(int id, int QuantityActionType)
        {
            var cartItem = await context.CartItems.FirstOrDefaultAsync(x => x.Id == id);

            if (cartItem == null)
                throw new Exception("Not found");

            if (QuantityActionType == 0)
            {
                if (cartItem.Quantity != 1)
                {
                    cartItem.Quantity--;
                }
            }

            if (QuantityActionType == 1)
                cartItem.Quantity++;

            context.CartItems.Attach(cartItem);
            context.Entry(cartItem).Property(x => x.Quantity).IsModified = true;
            await context.SaveChangesAsync();

            return cartItem;
        }

        public async Task<List<CartItemDto>> GetCardItems(string userId)
        {
            var query2 = from cit in context.CartItems
                         join pp in context.ProductPrices on cit.EditionId equals pp.EditionId
                         join p in context.Products on cit.ProductId equals p.Id
                         where cit.ProductId == pp.ProductId
                         where cit.UserId == userId
                         select new CartItemDto
                         {
                             Id = cit.Id,
                             EditionId = pp.EditionId,
                             ProductId = pp.ProductId,
                             EditionTitle = pp.Edition.Title,
                             ProductTitle = p.Title,
                             Image = p.Image,
                             Slug = p.Slug,
                             Price = pp.Price,
                             Quantity = cit.Quantity
                         };

            return query2.ToList();
        }
    }
}
