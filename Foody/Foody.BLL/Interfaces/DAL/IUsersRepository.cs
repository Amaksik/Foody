using Foody.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foody.BLL.Interfaces.DAL
{
    public interface IUsersRepository
    {
        Task<User> GetUserByIdAsync(int userId);
        Task<User> GetUserByChatIdAsync(string chatId);
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task AddUserAsync(User user);
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(int userId);
    }
}
