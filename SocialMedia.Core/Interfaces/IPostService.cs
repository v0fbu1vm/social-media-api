using Microsoft.AspNetCore.Mvc;
using SocialMedia.Core.Entities;
using SocialMedia.Core.Models.Post;
using SocialMedia.Core.Objects;

namespace SocialMedia.Core.Interfaces
{
    /// <summary>
    /// An interface for post related operations.
    /// </summary>
    public interface IPostService
    {
        /// <summary>
        /// Used for getting a list of posts shared by friends.
        /// </summary>
        /// <param name="amount">Represents the amount of posts that should be included.</param>
        /// <returns>
        /// The <see cref="Task"/> that represents the asynchronous operation,
        /// an <see cref="ICollection{Post}"/>.
        /// </returns>
        public Task<ICollection<Post>> GetRelevantPostsAsync(int amount);

        /// <summary>
        /// Used for getting a post.
        /// </summary>
        /// <param name="id">Represents the id of the post.</param>
        /// <returns>
        /// The <see cref="Task"/> that represents the asynchronous operation,
        /// a <see cref="Post"/>.
        /// </returns>
        public Task<Post?> GetPostByIdAsync(string id);

        /// <summary>
        /// Used for getting the content of a post.
        /// </summary>
        /// <param name="fileName">Represents the name of the file.</param>
        /// <returns>
        /// The <see cref="Task"/> that represents the asynchronous operation,
        /// a <see cref="FileStreamResult"/>.
        /// </returns>
        public Task<FileStreamResult?> GetPostContentAsync(string fileName);

        /// <summary>
        /// Used for posting.
        /// </summary>
        /// <param name="request">Represents the required data for posting.</param>
        /// <returns>
        /// The <see cref="Task"/> that represents the asynchronous operation.
        /// A <see cref="Result{Post}"/>, containing detailes of operation.
        /// </returns>
        public Task<Result<Post>> PostAsync(CreatePostRequest request);

        /// <summary>
        /// Used for updating a post.
        /// </summary>
        /// <param name="postId">Represents the id of the post.</param>
        /// <param name="request">Represents the required data for updating a post.</param>
        /// <returns>
        /// The <see cref="Task"/> that represents the asynchronous operation.
        /// A <see cref="Result{Post}"/>, containing detailes of operation.
        /// </returns>
        public Task<Result<Post>> UpdatePostAsync(string postId, UpdatePostRequest request);

        /// <summary>
        /// Used for deleting a post.
        /// </summary>
        /// <param name="id">Represents the id of the post.</param>
        /// <returns>
        /// The <see cref="Task"/> that represents the asynchronous operation.
        /// A <see cref="Result{bool}"/>, containing detailes of operation.
        /// </returns>
        public Task<Result<bool>> DeletePostAsync(string id);
    }
}