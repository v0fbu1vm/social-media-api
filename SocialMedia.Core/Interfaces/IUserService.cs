using SocialMedia.Core.Models;
using SocialMedia.Core.Objects;

namespace SocialMedia.Core.Interfaces
{
    /// <summary>
    /// An interface for user related operations.
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Generates an email confirmation token for the specified user.
        /// </summary>
        /// <param name="email">Represents the email of the user to generate an email confirmation token for.</param>
        /// <returns>
        /// The <see cref="Task"/> that represents the asynchronous operation,
        /// an <see cref="EmailConfirmationToken"/>
        /// </returns>
        public Task<EmailConfirmationToken?> GenerateEmailConfirmationTokenAsync(string email);
        /// <summary>
        /// Confirms an email for a specified user.
        /// </summary>
        /// <param name="userId">Represents the id of the user.</param>
        /// <param name="token">Represents the email confirmation token.</param>
        /// <returns>
        /// The <see cref="Task"/> that represents the asynchronous operation,
        /// an <see cref="Result{bool}"/> containing details of operation.
        /// </returns>
        public Task<Result<bool>> ConfirmEmailAsync(string userId, string token);
    }
}
