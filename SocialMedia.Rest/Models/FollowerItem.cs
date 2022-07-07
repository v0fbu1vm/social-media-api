namespace SocialMedia.Rest.Models
{
    /// <summary>
    /// Represents a dto for <see cref="SocialMedia.Core.Entities.Follower"/>.
    /// </summary>
    public class FollowerItem
    {
        /// <summary>
        /// Represents a unique identifier.
        /// </summary>
        public string Id { get; set; } = default!;

        /// <summary>
        /// Represents when a record was added to the system.
        /// </summary>
        public DateTime TimeStamp { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Represents the id of the <see cref="SocialMedia.Core.Entities.User"/> that is following the other user.
        /// </summary>
        public string UserId { get; set; } = default!;

        /// <summary>
        /// Represents the id of the <see cref="SocialMedia.Core.Entities.User"/> that is being followed.
        /// </summary>
        public string FolloweeId { get; set; } = default!;
    }
}