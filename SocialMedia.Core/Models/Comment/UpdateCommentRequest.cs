namespace SocialMedia.Core.Models.Comment
{
    /// <summary>
    /// A model for updating a <see cref="Entities.Comment"/>.
    /// </summary>
    public class UpdateCommentRequest
    {
        /// <summary>
        /// Represents the id of the comment.
        /// </summary>
        public string Id { get; set; } = default!;
        /// <summary>
        /// Represents the comment.
        /// </summary>
        public string Comment { get; set; } = default!;
    }
}
