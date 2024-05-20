using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foody.BLL.Interfaces.Internal
{
    public interface IUserService
    {
        Task<bool> IsRegistered(string chatId);
    }
}
