namespace SocialMedia.Core.Models.Message
{
    /// <summary>
    /// A model for creating a <see cref="Entities.Message"/>.
    /// </summary>
    public class CreateMessageRequest
    {
        /// <summary>
        /// Represents the id of the <see cref="Entities.User"/> that receives this message.
        /// </summary>
        public string RecipientId { get; set; } = default!;

        /// <summary>
        /// Represents the content of the message.
        /// </summary>
        public string Message { get; set; } = default!;
    }
}