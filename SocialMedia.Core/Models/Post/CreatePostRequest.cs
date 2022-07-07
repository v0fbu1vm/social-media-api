using Microsoft.AspNetCore.Http;

namespace SocialMedia.Core.Models.Post
{
    /// <summary>
    /// A model for creating a <see cref="Entities.Post"/>.
    /// </summary>
    public class CreatePostRequest
    {
        /// <summary>
        /// Represents a short caption.
        /// </summary>
        public string? Caption { get; set; } = default!;

        /// <summary>
        /// Represents a short description of the post.
        /// </summary>
        public string? Description { get; set; } = default!;

        /// <summary>
        /// Represents a file.
        /// </summary>
        public IFormFile File { get; set; } = default!;
    }
}