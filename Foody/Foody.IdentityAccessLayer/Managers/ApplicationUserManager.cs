using AutoMapper;
using Foody.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Foody.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Foody.IdentityAccessLayer.Record;

namespace Foody.IdentityAccessLayer.Managers
{
    public class ApplicationUserManager : ApplicationUserManagerBase<ApplicationUserRecord>, IApplicationUserManager
    {
        private readonly UserManager<ApplicationUserRecord> _userManager;
        private readonly SignInManager<ApplicationUserRecord> _signInManager;
        private readonly IMapper _mapper;
        

        public ApplicationUserManager(UserManager<ApplicationUserRecord> userManager, 
            SignInManager<ApplicationUserRecord> signInManager, IMapper mapper)
            : base(userManager, signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
        }

        public async Task<int> CreateAsync(ApplicationUser applicationUser)
        {
            var newUser = _mapper.Map<ApplicationUserRecord>(applicationUser, opts => { });

            newUser.CreationDate = DateTime.UtcNow;

            try
            {
                var userRegistrationResult = await _userManager.CreateAsync(newUser);

                if (!userRegistrationResult.Succeeded)
                {
                    var errors = string.Join(" ", userRegistrationResult.Errors.Select(e => $"{e.Code}: {e.Description}"));

                    throw new Exception(errors);
                }
            }
            catch (DbUpdateException ex)
            {
                //if (ex.IsUniqueConstraintViolationException(out var uniqueConstraintErrorKey)
                //    && uniqueConstraintErrorKey.Equals(applicationUserRecord.UniqueEmailConstraintName))
                //{
                //    throw new AggregateUniquenessConstraintViolationException(
                //        PocketDentist.Contracts.Shared.EntityFreamwork.ErrorMessagesConsts.UniqueConstraintViolation,
                //        UniqueConstraintViolationErrorKeyConsts.applicationUserEmailTaken, ex.InnerException);
                //}

                throw;
            }

            var createdUser = await _userManager.FindByEmailAsync(newUser.Email);

            await _userManager.AddToRoleAsync(createdUser, applicationUser.Role);

            return createdUser.Id;
        }

        public async Task<bool> UserExistsAsync(string email)
        {
            var userByEmail = await _userManager.FindByEmailAsync(email);

            return userByEmail != null;
        }

        public async Task<bool> UserExistsAsync(int userId)
        {
            var userById = await _userManager.FindByIdAsync(userId.ToString());

            return userById != null;
        }

        public async Task<bool> AccountActivationConfirmedAsync(int userId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());

            return user != null && user.EmailConfirmed;
        }

        public async Task<string> GenerateUserActivationLinkAsync(int userId)
        {
            var activationCode = await GenerateUserActivationCodeAsync(userId);
            var userActivationLink = $"account-activate?token={activationCode}&userid={userId}";

            return userActivationLink;
        }

        public async Task<string> GenerateUserActivationCodeAsync(int userId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            var activationCode = await _userManager.GenerateEmailConfirmationTokenAsync(user);

            return activationCode;
        }

        public async Task<bool> UpdateRolesAsync(int userId, IReadOnlyList<string> roles)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            var currentRoles = await _userManager.GetRolesAsync(user);

            if (currentRoles.Count == roles.Count() && currentRoles.All(roles.Contains))
            {
                return false;
            }

            await _userManager.RemoveFromRolesAsync(user, currentRoles);
            await _userManager.AddToRolesAsync(user, roles);

            return true;
        }

        public async Task<ApplicationUser> GetByIdAsync(int userId)
        {
            var storedUser = await _userManager.FindByIdAsync(userId.ToString());

            return _mapper.Map<ApplicationUser>(storedUser);
        }

        public async Task<string> GeneratePasswordResetTokenAsync(int userId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            var passwordResetCode = await _userManager.GeneratePasswordResetTokenAsync(user);

            return passwordResetCode;
        }

        public async Task<bool> ResetPasswordAsync(int userId, string newPassword, string resetPasswordToken)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            var passwordResetResult = await _userManager.ResetPasswordAsync(user, resetPasswordToken, newPassword);

            return passwordResetResult.Succeeded;
        }

        public override async Task<(int userId, string resetPasswordLink)> GenerateResetPasswordLink(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user == null)
            {
                throw new Exception("User With Email Not In The System");
            }

            var userActivated = await _signInManager.CanSignInAsync(user);

            if (userActivated ||
                await _userManager.IsInRoleAsync(user, nameof(Roles.Client)))
            {
                return await base.GenerateResetPasswordLink(email);
            }

            throw new Exception("PasswordRecoveryFailed");
        }

        public async Task BlockAsync(int userId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());

            if (user == null)
            {
                throw new Exception("ItemNotFound");
            }

            var lockoutResult = await _userManager.SetLockoutEndDateAsync(user, DateTimeOffset.MaxValue);
            if (!lockoutResult.Succeeded)
            {
                var errors = string.Join(" ", lockoutResult.Errors.Select(e => $"{e.Code}: {e.Description}"));

                throw new Exception(errors);
            }

            var securityStampResult = await _userManager.UpdateSecurityStampAsync(user);
            if (!securityStampResult.Succeeded)
            {
                var errors = string.Join(" ", securityStampResult.Errors.Select(e => $"{e.Code}: {e.Description}"));

                throw new Exception(errors);
            }
        }

        public async Task UnblockAsync(int userId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());

            if (user == null)
            {
                throw new Exception("ItemNotFound");
            }

            if (await _userManager.IsLockedOutAsync(user))
            {
                var lockoutResult = await _userManager.SetLockoutEndDateAsync(user, DateTimeOffset.UtcNow);
                if (!lockoutResult.Succeeded)
                {
                    var errors = string.Join(" ", lockoutResult.Errors.Select(e => $"{e.Code}: {e.Description}"));

                    throw new Exception(errors);
                }
            }
        }

        public async Task<IList<ApplicationUser>> GetActiveUsersInRoleAsync(string role)
        {
            var users = await _userManager.GetUsersInRoleAsync(role);
            var activeUsers = users.Where(u => u.EmailConfirmed && u.IsEnabled);
            return _mapper.Map<IList<ApplicationUser>>(activeUsers);
        }
    }
}
