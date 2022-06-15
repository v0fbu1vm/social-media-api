using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace SocialMedia.Core.Entities
{
    /// <summary>
    /// Represents a <see cref="User"/>.
    /// </summary>
    public class User : IdentityUser
    {
        /// <summary>
        /// Represents the first-name of a user.
        /// </summary>
        [Required]
        [MinLength(2)]
        [MaxLength(30)]
        public string FirstName { get; set; } = default!;
        /// <summary>
        /// Represents the last-name of a user.
        /// </summary>
        [Required]
        [MinLength(2)]
        [MaxLength(30)]
        public string LastName { get; set; } = default!;
        /// <summary>
        /// Represents the url of the user profile image.
        /// </summary>
        public string? ProfileImageUrl { get; set; } = default!;
        /// <summary>
        /// Represents when a record was added to the system.
        /// </summary>
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;
        /// <summary>
        /// Represents when a record was modified.
        /// </summary>
        public DateTime DateModified { get; set; } = DateTime.UtcNow;
        /// <summary>
        /// Represents a list of <see cref="Message"/>'s a user has sent.
        /// </summary>
        public virtual ICollection<Message> MessagesSent { get; set; } = new List<Message>();
        /// <summary>
        /// Represents a list of <see cref="Message"/>'s a user has received.
        /// </summary>
        public virtual ICollection<Message> MessagesReceived { get; set; } = new List<Message>();
        /// <summary>
        /// Represents a list of <see cref="Post"/>'s shared by a user.
        /// </summary>
        public virtual ICollection<Post> Posts { get; set; } = new List<Post>();
        /// <summary>
        /// Represents a list of <see cref="Comment"/>'s a user has commented on <see cref="Post"/>'s.
        /// </summary>
        public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();
        /// <summary>
        /// Represents a list of <see cref="Follower"/>'s that are following this user.
        /// </summary>
        public virtual ICollection<Follower> Followers { get; set; } = new List<Follower>();
        /// <summary>
        /// Represents a list of <see cref="Follower"/>'s that are being followed by this user.
        /// </summary>
        public virtual ICollection<Follower> Following { get; set; } = new List<Follower>();
    }
}
