using System.Collections.Generic;
using System.Threading.Tasks;
using commerce.Models;
using commerce.Repository;

namespace commerce.Services
{
    public class CartItemService : ICartItemService
    {
        private readonly ICartItemRepository _cartItemRepository;

        public CartItemService(ICartItemRepository cartItemRepository)
        {
            _cartItemRepository = cartItemRepository;
        }

        public async Task AddCartItemAsync(CartItem cartItem)
        {
            await _cartItemRepository.AddCartItemAsync(cartItem);
        }

        public async Task<List<CartItem>> GetCartItemsByCartIdAsync(int cartId)
        {
            return await _cartItemRepository.GetCartItemsByCartIdAsync(cartId);
        }

        public async Task<CartItem> GetCartItemByIdAsync(int cartItemId)
        {
            return await _cartItemRepository.GetCartItemByIdAsync(cartItemId);
        }
        public async Task<decimal> GetTotalPriceByCartIdAsync(int cartId)
        {
            var cartItems = await _cartItemRepository.GetCartItemsByCartIdAsync(cartId);
            decimal totalPrice = 0;

            foreach (var item in cartItems)
            {
                totalPrice += item.Quantity * item.Product.Price;
            }

            return totalPrice;
        }

        public async Task UpdateCartItemAsync(CartItem cartItem)
        {
            await _cartItemRepository.UpdateCartItemAsync(cartItem);
        }

        public async Task DeleteCartItemAsync(int cartItemId)
        {
            await _cartItemRepository.DeleteCartItemAsync(cartItemId);
        }
    }
}