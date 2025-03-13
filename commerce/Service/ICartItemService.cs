using System.Collections.Generic;
using System.Threading.Tasks;
using commerce.Models;

namespace commerce.Services
{
    public interface ICartItemService
    {
        Task AddCartItemAsync(CartItem cartItem);
        Task<List<CartItem>> GetCartItemsByCartIdAsync(int cartId);
        Task<CartItem> GetCartItemByIdAsync(int cartItemId);
        Task UpdateCartItemAsync(CartItem cartItem);
        Task DeleteCartItemAsync(int cartItemId);
        Task<decimal> GetTotalPriceByCartIdAsync(int cartId);
    }
}