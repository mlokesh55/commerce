using commerce.Models;
using Microsoft.EntityFrameworkCore;

namespace commerce.Repository
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        private readonly CartContext _context;

        public ShoppingCartRepository(CartContext context)
        {
            _context = context;
        }

        public async Task AddShoppingCartAsync(ShoppingCart shoppingCart)
        {
            await _context.ShoppingCartTable.AddAsync(shoppingCart);
            await _context.SaveChangesAsync();
        }

        public async Task<ShoppingCart> GetShoppingCartByUserIdAsync(int userId)
        {
            return await _context.ShoppingCartTable.FirstOrDefaultAsync(sc => sc.UserId == userId);
        }
    }
}
