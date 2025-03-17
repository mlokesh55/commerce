using commerce.Models;

namespace commerce.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly CartContext _context;

        public UserRepository(CartContext context)
        {
            _context = context;
        }

        public async Task AddUserAsync(User user)
        {
            await _context.User.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task<User> GetUserByIdAsync(int userId)
        {
            return await _context.User.FindAsync(userId);
        }

        public async Task DeleteUserAsync(int userId)
        {
            var user = await _context.User.FindAsync(userId);
            if (user != null)
            {
                _context.User.Remove(user);
                await _context.SaveChangesAsync();
            }
        }
    }
}
