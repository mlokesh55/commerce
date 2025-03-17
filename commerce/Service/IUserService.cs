using commerce.Models;
using System.Threading.Tasks;

namespace commerce.Services
{
    public interface IUserService
    {
        Task CreateUserAsync(User user);
        Task<User> GetUserByIdAsync(int userId);
        Task DeleteUserAsync(int userId);
    }
}