using System.ComponentModel.DataAnnotations;

namespace SocialMedia.Core.Entities
{
    /// <summary>
    /// Represents a <see cref="Message"/>.
    /// </summary>
    public class Message : AbstractEntity
    {
        /// <summary>
        /// Represents the content of the message.
        /// </summary>
        [Required]
        [MinLength(1)]
        [MaxLength(1000)]
        public string Content { get; set; } = default!;

        /// <summary>
        /// Represents the id of the <see cref="User"/> that sent this message.
        /// </summary>
        [Required]
        [MaxLength(450)]
        public string SenderId { get; set; } = default!;

        /// <summary>
        /// Represents the <see cref="User"/> that sent this message.
        /// </summary>
        public virtual User Sender { get; set; } = default!;

        /// <summary>
        /// Represents the id of the <see cref="User"/> that received this message.
        /// </summary>
        [Required]
        [MaxLength(450)]
        public string RecipientId { get; set; } = default!;

        /// <summary>
        /// Represents the <see cref="User"/> that received this message.
        /// </summary>
        public virtual User Recipient { get; set; } = default!;
    }
}