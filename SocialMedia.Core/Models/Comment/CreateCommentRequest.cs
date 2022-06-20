namespace SocialMedia.Core.Models.Comment
{
    /// <summary>
    /// A model for creating a <see cref="Entities.Comment"/>.
    /// </summary>
    public class CreateCommentRequest
    {
        /// <summary>
        /// Represents the id of the <see cref="Entities.Post"/> in which this comment was commented on.
        /// </summary>
        public string PostId { get; set; } = default!;
        /// <summary>
        /// Represents the comment.
        /// </summary>
        public string Comment { get; set; } = default!;
    }
}
