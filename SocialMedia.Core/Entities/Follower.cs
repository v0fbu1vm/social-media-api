using System.ComponentModel.DataAnnotations;

namespace SocialMedia.Core.Entities
{
    /// <summary>
    /// Represents a <see cref="Follower"/>.
    /// </summary>
    public class Follower
    {
        /// <summary>
        /// Represents a unique identifier.
        /// </summary>
        [Required]
        [MaxLength(450)]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        /// <summary>
        /// Represents when a record was added to the system.
        /// </summary>
        public DateTime TimeStamp { get; set; } = DateTime.UtcNow;
        /// <summary>
        /// Represents the id of the <see cref="Entities.User"/> that is following the other user.
        /// </summary>
        [Required]
        [MaxLength(450)]
        public string UserId { get; set; } = default!;
        /// <summary>
        /// Represents the <see cref="Entities.User"/> that is following the other user.
        /// </summary>
        public virtual User User { get; set; } = default!;
        /// <summary>
        /// Represents the id of the <see cref="Entities.User"/> that is being followed.
        /// </summary>
        [Required]
        [MaxLength(450)]
        public string FolloweeId { get; set; } = default!;
        /// <summary>
        /// Represents the <see cref="Entities.User"/> that is being followed.
        /// </summary>
        public virtual User Followee { get; set; } = default!;
    }
}
