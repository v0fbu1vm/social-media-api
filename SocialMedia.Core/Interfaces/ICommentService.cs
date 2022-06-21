using SocialMedia.Core.Entities;
using SocialMedia.Core.Models.Comment;
using SocialMedia.Core.Objects;

namespace SocialMedia.Core.Interfaces
{
    /// <summary>
    /// An interface for comment related operations.
    /// </summary>
    public interface ICommentService
    {
        /// <summary>
        /// Gets all comments, commented by the authenticated user.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/> that represents the asynchronous operation,
        /// a <see cref="ICollection{Comment}"/>.
        /// </returns>
        public Task<ICollection<Comment>> GetCommentsAsync();
        /// <summary>
        /// Gets a list of comments, commented on a post.
        /// </summary>
        /// <param name="postId">Represents the id of the post.</param>
        /// <param name="amount">Represents the amount of comments that should be included.</param>
        /// <returns>
        /// The <see cref="Task"/> that represents the asynchronous operation,
        /// a <see cref="ICollection{Comment}"/>.
        /// </returns>
        public Task<ICollection<Comment>> GetCommentsForPostAsync(string postId, int amount);
        /// <summary>
        /// Used for getting a comment.
        /// </summary>
        /// <param name="id">Represents the id of the comment.</param>
        /// <returns>
        /// The <see cref="Task"/> that represents the asynchronous operation,
        /// a <see cref="Comment"/>.
        /// </returns>
        public Task<Comment?> GetCommentByIdAsync(string id);
        /// <summary>
        /// Used for commenting on a post.
        /// </summary>
        /// <param name="request">Represents the required data for commenting on a post.</param>
        /// <returns>
        /// The <see cref="Task"/> that represents the asynchronous operation.
        /// A <see cref="Result{Comment}"/>, containing detailes of operation.
        /// </returns>
        public Task<Result<Comment>> CommentAsync(CreateCommentRequest request);
        /// <summary>
        /// Used for updating a commenting on a post.
        /// </summary>
        /// <param name="id">Represents the id of the comment.</param>
        /// <param name="request">Represents the required data for updating a commenting on a post.</param>
        /// <returns>
        /// The <see cref="Task"/> that represents the asynchronous operation.
        /// A <see cref="Result{Comment}"/>, containing detailes of operation.
        /// </returns>
        public Task<Result<Comment>> UpdateCommentAsync(string id, UpdateCommentRequest request);
        /// <summary>
        /// Used for deleting a comment.
        /// </summary>
        /// <param name="id">Represents the id of the comment.</param>
        /// <returns>
        /// The <see cref="Task"/> that represents the asynchronous operation.
        /// A <see cref="Result{bool}"/>, containing detailes of operation.
        /// </returns>
        public Task<Result<bool>> DeleteCommentAsync(string id);
    }
}
