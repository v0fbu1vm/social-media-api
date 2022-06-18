namespace SocialMedia.Core.Models.Post
{
    /// <summary>
    /// A model for updating a <see cref="Entities.Post"/>.
    /// </summary>
    public class UpdatePostRequest
    {
        /// <summary>
        /// Represents the id of the post.
        /// </summary>
        public string Id { get; set; } = default!;
        /// <summary>
        /// Represents a short caption.
        /// </summary>
        public string? Caption { get; set; } = default!;
        /// <summary>
        /// Represents a short description of the post.
        /// </summary>
        public string? Description { get; set; } = default!;
    }
}
