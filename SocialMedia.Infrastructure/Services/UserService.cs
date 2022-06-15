using Microsoft.AspNetCore.Identity;
using SocialMedia.Core.Entities;
using SocialMedia.Core.Enums;
using SocialMedia.Core.Interfaces;
using SocialMedia.Core.Models;
using SocialMedia.Core.Objects;
using SocialMedia.Infrastructure.Extensions;

namespace SocialMedia.Infrastructure.Services
{
    /// <summary>
    /// An service for user related operation.
    /// </summary>
    public class UserService : IDisposable, IUserService
    {
        private readonly UserManager<User> _userManager;

        public UserService(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        #region ConfirmEmailAsync
        /// <inheritdoc cref="IUserService.ConfirmEmailAsync(string, string)"/>
        /// <remarks>
        /// May produce the following errors.
        /// <list type="bullet">
        /// <item><see cref="ErrorType.BadRequest"/></item>
        /// <item><see cref="ErrorType.NotFound"/></item>
        /// </list>
        /// </remarks>
        public async Task<Result<bool>> ConfirmEmailAsync(string userId, string token)
        {
            if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(token) || !Guid.TryParse(userId, out _))
            {
                return Result<bool>.Failure(ErrorType.BadRequest, "Invalid input.");
            }

            var user = await _userManager.FindByIdAsync(userId);

            if (user != null)
            {
                if(!user.EmailConfirmed)
                {
                    var result = await _userManager.ConfirmEmailAsync(user, token);

                    return result.Succeeded ? Result<bool>.Success(true)
                        : Result<bool>.Failure(ErrorType.BadRequest, result.ErrorMessage());
                }

                return Result<bool>.Failure(ErrorType.BadRequest, "Email already confirmed.");
            }

            return Result<bool>.Failure(ErrorType.NotFound, "User not found.");

        }
        #endregion

        #region GenerateEmailConfirmationTokenAsync
        /// <inheritdoc cref="IUserService.GenerateEmailConfirmationTokenAsync(string)"/>
        public async Task<EmailConfirmationToken?> GenerateEmailConfirmationTokenAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);

            return user != null ? new EmailConfirmationToken()
            {
                User = user,
                Token = await _userManager.GenerateEmailConfirmationTokenAsync(user)
            }
            : null;
        }
        #endregion

        public void Dispose()
        {
            GC.SuppressFinalize(this);
            _userManager.Dispose();
        }
    }
}
