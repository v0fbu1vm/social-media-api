using System.ComponentModel.DataAnnotations;

namespace SocialMedia.Core.Entities
{
    /// <summary>
    /// Represents a <see cref="Comment"/>.
    /// </summary>
    public class Comment : AbstractEntity
    {
        /// <summary>
        /// Represents the content of the comment.
        /// </summary>
        [Required]
        [MinLength(1)]
        [MaxLength(1000)]
        public string Content { get; set; } = default!;
        /// <summary>
        /// Represents the id of the <see cref="Entities.User"/> that made this comment.
        /// </summary>
        [Required]
        [MaxLength(450)]
        public string UserId { get; set; } = default!;
        /// <summary>
        /// Represents the <see cref="Entities.User"/> that made this comment.
        /// </summary>
        public virtual User User { get; set; } = default!;
        /// <summary>
        /// Represents the id of the <see cref="Entities.Post"/> in which this comment was commented on.
        /// </summary>
        [Required]
        [MaxLength(450)]
        public string PostId { get; set; } = default!;
        /// <summary>
        /// Represents the <see cref="Entities.Post"/> in which this comment was commented on.
        /// </summary>
        public virtual Post Post { get; set; } = default!;
    }
}
