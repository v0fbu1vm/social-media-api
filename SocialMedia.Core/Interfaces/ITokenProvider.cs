using SocialMedia.Core.Entities;
using SocialMedia.Core.Models.Auth;

namespace SocialMedia.Core.Interfaces
{
    /// <summary>
    /// An interface for token related operations.
    /// </summary>
    public interface ITokenProvider
    {
        /// <summary>
        /// Generates a token for a given <see cref="User"/>.
        /// </summary>
        /// <param name="user">Represents the <see cref="User"/> that needs the token.</param>
        /// <returns>
        /// The generated <see cref="Token"/>. Where a token and it's expiration date
        /// is imbedded into it.
        /// </returns>
        public Token GenerateToken(User user);
    }
}
