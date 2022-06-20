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
