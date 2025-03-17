using commerce.Models;
using commerce.Repository;
using System.Threading.Tasks;

namespace commerce.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IShoppingCartRepository _shoppingCartRepository;

        public UserService(IUserRepository userRepository, IShoppingCartRepository shoppingCartRepository)
        {
            _userRepository = userRepository;
            _shoppingCartRepository = shoppingCartRepository;
        }

        public async Task CreateUserAsync(User user)
        {
            // Add the user to the database
            await _userRepository.AddUserAsync(user);

            // Create a shopping cart for the new user
            var shoppingCart = new ShoppingCart
            {
                UserId = user.UserId
            };

            await _shoppingCartRepository.AddShoppingCartAsync(shoppingCart);

            // Optionally, assign the shopping cart to the user object
            user.ShoppingCart = shoppingCart;
        }

        public async Task<User> GetUserByIdAsync(int userId)
        {
            return await _userRepository.GetUserByIdAsync(userId);
        }

        public async Task DeleteUserAsync(int userId)
        {
            await _userRepository.DeleteUserAsync(userId);
        }
    }
}