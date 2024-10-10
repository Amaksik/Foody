using Foody.Domain.Interfaces;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foody.IdentityAccessLayer.Managers
{
    public abstract class ApplicationUserManagerBase<T> : IApplicationUserManagerBase where T : IdentityUser<int>
    {
        private readonly UserManager<T> _userManager;
        private readonly SignInManager<T> _signInManager;

        public ApplicationUserManagerBase(UserManager<T> userManager, SignInManager<T> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public virtual async Task<(int userId, string resetPasswordLink)> GenerateResetPasswordLink(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user == null)
            {
                throw new Exception("Validation Error User With Email Not In The System");
            }

            var resetPasswordToken = await _userManager.GeneratePasswordResetTokenAsync(user);
            var resetPasswordLink = $"/new-password?token={resetPasswordToken}&userid={user.Id}";
            return (user.Id, resetPasswordLink);
        }

        public async Task<bool> ValidatePasswordRecoveryToken(int userId, string passwordRecoveryToken)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());

            if (user == null) return false;

            return await _userManager.VerifyUserTokenAsync(user,
                _userManager.Options.Tokens.PasswordResetTokenProvider, UserManager<T>.ResetPasswordTokenPurpose,
                passwordRecoveryToken);
        }

        public async Task<bool> VerifyUserTokenAsync(int userId, string activationToken)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());

            if (user == null) return false;

            return await _userManager.VerifyUserTokenAsync(user,
                _userManager.Options.Tokens.EmailConfirmationTokenProvider, UserManager<T>.ConfirmEmailTokenPurpose,
                activationToken);
        }

        public async Task<bool> ConfirmEmailAsync(int userId, string activationToken)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());

            if (user == null) return false;

            var activationResult = await _userManager.ConfirmEmailAsync(user, activationToken);

            return activationResult.Succeeded;
        }

        public async Task<bool> IsUserAccountActivatedAsync(int userId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());

            return user.EmailConfirmed;
        }

        public async Task<bool> SetUserPasswordAsync(int userId, string password)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());

            if (user == null)
            {
                throw new Exception();
            }

            foreach (var passwordValidator in _userManager.PasswordValidators)
            {
                var passwordValidationResult = await passwordValidator.ValidateAsync(_userManager, user, password);

                if (!passwordValidationResult.Succeeded)
                {
                    return false;
                }
            }

            var userPasswordSetupResult = await _userManager.AddPasswordAsync(user, password);

            if (!userPasswordSetupResult.Succeeded)
            {
                var errors = string.Join(" ", userPasswordSetupResult.Errors.Select(e => $"{e.Code}: {e.Description}"));

                throw new Exception(errors);
            }

            return true;
        }

        public async Task ChangePasswordAsync(int userId, string oldPassword, string newPassword)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());

            if (user == null)
            {
                throw new Exception();
            }
            var passwordChangeResult = await _userManager.ChangePasswordAsync(user, oldPassword, newPassword);

            if (!passwordChangeResult.Succeeded)
            {
                if (passwordChangeResult.Errors.First().Code == "PasswordMismatch")
                {
                    throw new Exception("Current password is incorrect");
                }

                throw new Exception(passwordChangeResult.Errors.Select(e => e.Description).ToArray().ToString());
            }
        }
    }
}
