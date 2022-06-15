using SocialMedia.Core.Entities;

namespace SocialMedia.Core.Models.Auth
{
    /// <summary>
    /// A response model for authentication.
    /// </summary>
    public class LoginResponse
    {
        /// <summary>
        /// Represents a token.
        /// </summary>
        public Token Token { get; set; } = default!;
        /// <summary>
        /// Represents a user.
        /// </summary>
        public User User { get; set; } = default!;
    }
}
