using E_Commerce.Application.DTOs;
using E_Commerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.Interfaces
{
    public interface ICartRepository : IMainRepository<CartItem, int>
    {
        public Task<CartItem> AddToCart(CartItem entity);
        public Task<CartItem> UpdateQuantity(int id, int QuantityActionType);
        Task<List<CartItemDto>> GetCardItems(string userId);
    }
}
