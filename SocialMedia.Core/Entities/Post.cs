using SocialMedia.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace SocialMedia.Core.Entities
{
    /// <summary>
    /// Represents a <see cref="Post"/>.
    /// </summary>
    public class Post : AbstractEntity
    {
        /// <summary>
        /// Represents a short caption.
        /// </summary>
        [MaxLength(255)]
        public string Caption { get; set; } = default!;
        /// <summary>
        /// Represents a short description of the post.
        /// </summary>
        [MaxLength(280)]
        public string Description { get; set; } = default!;
        /// <summary>
        /// Represents the type of the post. Whether it's a photo or video.
        /// </summary>
        public PostType Type { get; set; }
        /// <summary>
        /// Represents the id of the <see cref="Entities.User"/> that shared this post.
        /// </summary>
        [Required]
        [MaxLength(450)]
        public string UserId { get; set; } = default!;
        /// <summary>
        /// Represents the <see cref="Entities.User"/> that shared this post.
        /// </summary>
        public virtual User User { get; set; } = default!;
        /// <summary>
        /// Represents a list of comments made on this post.
        /// </summary>
        public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();
    }
}
