using Foody.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foody.Domain.Interfaces
{
    public interface IApplicationUserManager : IApplicationUserManagerBase
    {
        Task<int> CreateAsync(ApplicationUser user);

        Task<bool> UserExistsAsync(string email);

        Task<bool> UserExistsAsync(int userId);

        Task<bool> AccountActivationConfirmedAsync(int userId);

        Task<string> GenerateUserActivationLinkAsync(int userId);

        Task<string> GenerateUserActivationCodeAsync(int userId);

        Task<bool> UpdateRolesAsync(int userId, IReadOnlyList<string> roles);

        Task<bool> SetUserPasswordAsync(int userId, string password);

        Task<ApplicationUser> GetByIdAsync(int userId);

        Task<string> GeneratePasswordResetTokenAsync(int userId);

        Task<bool> ResetPasswordAsync(int userId, string newPassword, string resetPasswordToken);

        Task BlockAsync(int userId);

        Task UnblockAsync(int userId);

        Task<IList<ApplicationUser>> GetActiveUsersInRoleAsync(string role);
    }
}
