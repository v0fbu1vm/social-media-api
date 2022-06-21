using SocialMedia.Core.Entities;
using SocialMedia.Core.Interfaces;

namespace SocialMedia.GraphQL.Queries
{
    [ExtendObjectType(OperationTypeNames.Query)]
    public class CommentQueries
    {
        #region GetCommentsAsync
        /// <summary>
        /// Used for getting a list of comments, commented by the authenticated user.
        /// </summary>
        /// <param name="service">A service for <see cref="Comment"/> related operations.</param>
        /// <returns>
        /// The <see cref="Task"/> that represents the asynchronous operation,
        /// an <see cref="ICollection{Comment}"/>.
        /// </returns>
        public async Task<ICollection<Comment>> GetCommentsAsync([Service] ICommentService service)
        {
            return await service.GetCommentsAsync();
        }
        #endregion

        #region GetCommentsForPostAsync
        /// <summary>
        /// Used for getting a list of comments, commented on a post.
        /// </summary>
        /// <param name="postId">Represents the id of the post.</param>
        /// <param name="amount">Represents the amount of comments that should be include.</param>
        /// <param name="service">A service for <see cref="Comment"/> related operations.</param>
        /// <returns>
        /// The <see cref="Task"/> that represents the asynchronous operation,
        /// an <see cref="ICollection{Comment}"/>.
        /// </returns>
        public async Task<ICollection<Comment>> GetCommentsForPostAsync(string postId, int amount, [Service] ICommentService service)
        {
            return await service.GetCommentsForPostAsync(postId, amount);
        }
        #endregion

        #region GetCommentAsync
        /// <summary>
        /// Used for getting a comment by id.
        /// </summary>
        /// <param name="id">Represents the id of the comment.</param>
        /// <param name="service">A service for <see cref="Comment"/> related operations.</param>
        /// <returns>
        /// The <see cref="Task"/> that represents the asynchronous operation,
        /// a <see cref="Comment"/>.
        /// </returns>
        public async Task<Comment?> GetCommentAsync(string id, [Service] ICommentService service)
        {
            return await service.GetCommentByIdAsync(id);
        }
        #endregion
    }
}
