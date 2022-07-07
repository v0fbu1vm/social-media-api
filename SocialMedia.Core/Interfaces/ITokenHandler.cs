using SocialMedia.Core.Entities;
using SocialMedia.Core.Models;
using System.Security.Claims;

namespace SocialMedia.Core.Interfaces
{
    /// <summary>
    /// An interface for token related operations.
    /// </summary>
    public interface ITokenHandler
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

        /// <summary>
        /// Checks whether or not a specified token is valid.
        /// </summary>
        /// <param name="token">Represents a token.</param>
        /// <returns>
        /// <see langword="true"/> if token is valid, otherwise <see langword="false"/>.
        /// </returns>
        public bool IsTokenValid(string token);

        /// <summary>
        /// Gets a list of claims.
        /// </summary>
        /// <param name="token">Represents a token.</param>
        /// <returns>
        /// A list of <see cref="Claim"/>'s.
        /// </returns>
        public IEnumerable<Claim> GetClaims(string token);
    }
}