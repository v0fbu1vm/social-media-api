namespace SocialMedia.Core.Models.Auth
{
    /// <summary>
    /// A model for authenticating a <see cref="Entities.User"/>.
    /// </summary>
    public class LoginRequest
    {
        /// <summary>
        /// Represents the email of a user.
        /// </summary>
        public string Email { get; set; } = default!;
        /// <summary>
        /// Represents the password of a user.
        /// </summary>
        public string Password { get; set; } = default!;
    }
}
