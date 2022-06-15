using SocialMedia.Core.Models.Auth;
using SocialMedia.Core.Objects;

namespace SocialMedia.Core.Interfaces
{
    /// <summary>
    /// An interface for authentication related operations.
    /// </summary>
    public interface IAuthService
    {
        /// <summary>
        /// Used for registering a user.
        /// </summary>
        /// <param name="request">Represents the required data for registering a user.</param>
        /// <returns>
        /// A <see cref="Result{RegisterResponse}"/>, containing the details of operation.
        /// </returns>
        public Task<Result<bool>> RegisterAsync(RegisterRequest request);
        /// <summary>
        /// Used for signing a user in.
        /// </summary>
        /// <param name="request">Represents the required data for signing a user in.</param>
        /// <returns>
        /// A <see cref="Result{LoginResponse}"/>, containing the details of operation.
        /// </returns>
        public Task<Result<LoginResponse>> SignInAsync(LoginRequest request);
    }
}
