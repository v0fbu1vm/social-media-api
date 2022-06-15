using SocialMedia.Core.Entities;

namespace SocialMedia.Core.Models
{
    public class EmailConfirmationToken
    {
        /// <summary>
        /// Represents the id of the user.
        /// </summary>
        public User User { get; set; } = default!;
        /// <summary>
        /// Represents the email confirmation token.
        /// </summary>
        public string Token { get; set; } = default!;
    }
}
