using commerce.Models;

namespace commerce.Repository
{
    public interface IUserRepository
    {
        Task AddUserAsync(User user);
        Task<User> GetUserByIdAsync(int userId);
        Task DeleteUserAsync(int userId);
    }
}
