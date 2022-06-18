namespace SocialMedia.Core.Models
{
    /// <summary>
    /// Represents a Token. Where a token is imbedded into it,
    /// with it's expiration date.
    /// </summary>
    public class Token
    {
        /// <summary>
        /// Represents the token.
        /// </summary>
        public string Content { get; set; } = default!;
        /// <summary>
        /// Represents the expiration date of the imbedded jwt.
        /// </summary>
        public DateTime ExpirationDate { get; set; } = DateTime.UtcNow;
    }
}
