namespace SocialMedia.Core.Models.Auth
{
    /// <summary>
    /// A model for registring a new <see cref="Entities.User"/>.
    /// </summary>
    public class RegisterRequest 
    {
        /// <summary>
        /// Represents the first-name of a user.
        /// </summary>
        public string FirstName { get; set; } = default!;
        /// <summary>
        /// Represents the last-name of a user.
        /// </summary>
        public string LastName { get; set; } = default!;
        /// <summary>
        /// Represents the email of the user.
        /// </summary>
        public string Email { get; set; } = default!;
        /// <summary>
        /// Represents the password of the user.
        /// </summary>
        public string Password { get; set; } = default!;
    }
}
