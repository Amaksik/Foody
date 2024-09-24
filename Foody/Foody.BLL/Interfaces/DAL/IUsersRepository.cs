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
        Task<User> GetFullUserByChatIdAsync(string chatId);
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task AddUserAsync(User user);
        Task UpdateUserAsync(User user);
        Task UpdateUserConfigurationAsync<T>(string chatId, T config) where T : class;
        Task DeleteUserAsync(int userId);
    }
}
