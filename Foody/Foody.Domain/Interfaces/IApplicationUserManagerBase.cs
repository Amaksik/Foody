using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foody.Domain.Interfaces
{
    public interface IApplicationUserManagerBase
    {
        Task<(int userId, string resetPasswordLink)> GenerateResetPasswordLink(string email);

        Task<bool> ValidatePasswordRecoveryToken(int userId, string passwordRecoveryToken);

        Task<bool> VerifyUserTokenAsync(int userId, string activationToken);

        Task<bool> ConfirmEmailAsync(int userId, string activationToken);

        Task<bool> IsUserAccountActivatedAsync(int userId);

        Task ChangePasswordAsync(int userId, string oldPassword, string newPassword);
    }
}
