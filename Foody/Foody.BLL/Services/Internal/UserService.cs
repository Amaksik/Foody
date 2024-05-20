using Foody.BLL.Interfaces.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foody.BLL.Services.Internal
{
    public class UserService
    {
        private readonly IUsersRepository _usersRepository;
        public UserService( IUsersRepository usersRepository) 
        {
            _usersRepository = usersRepository;
        }

        async Task<bool> IsRegistered(string chatId)
        {
            var user = await _usersRepository.GetUserByChatIdAsync(chatId);
            return user != null ? true: false;
        }
    }
}
