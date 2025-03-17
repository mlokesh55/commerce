using commerce.Models;

namespace commerce.Repository
{
    public interface IShoppingCartRepository
    {
        Task AddShoppingCartAsync(ShoppingCart shoppingCart);
        Task<ShoppingCart> GetShoppingCartByUserIdAsync(int userId);
    }
}
