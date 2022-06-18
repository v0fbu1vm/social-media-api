using SocialMedia.Core.Entities;
using SocialMedia.Core.Objects;

namespace SocialMedia.Core.Interfaces
{
    /// <summary>
    /// An interface for follower related operations.
    /// </summary>
    public interface IFollowerService
    {
        /// <summary>
        /// Used for following a <see cref="Entities.User"/>.
        /// </summary>
        /// <param name="userId">Represents the id of the <see cref="Entities.User"/>.</param>
        /// <returns>
        /// The <see cref="Task"/> that represents the asynchronous operation,
        /// an <see cref="Result{Follower}"/>.
        /// </returns>
        public Task<Result<Follower>> FollowAsync(string userId);
        /// <summary>
        /// Used for unfollowing a <see cref="Entities.User"/>.
        /// </summary>
        /// <param name="userId">Represents the id of the <see cref="Entities.User"/>.</param>
        /// <returns>
        /// The <see cref="Task"/> that represents the asynchronous operation,
        /// an <see cref="Result{bool}"/>.
        /// </returns>
        public Task<Result<bool>> UnFollowAsync(string userId);
        /// <summary>
        /// Gets a <see cref="Follower"/>.
        /// </summary>
        /// <param name="userId">Represents the id of the <see cref="Entities.User"/>.</param>
        /// <returns>
        /// The <see cref="Task"/> that represents the asynchronous operation,
        /// a <see cref="Follower"/>.
        /// </returns>
        public Task<Follower?> GetFollowerAsync(string userId);
        /// <summary>
        /// Gets a <see cref="Follower"/>.
        /// </summary>
        /// <param name="userId">Represents the id of the <see cref="Entities.User"/>.</param>
        /// <returns>
        /// The <see cref="Task"/> that represents the asynchronous operation,
        /// a <see cref="Follower"/>.
        /// </returns>
        public Task<Follower?> GetFolloweeAsync(string userId);
        /// <summary>
        /// Gets a list of <see cref="Follower"/>'s.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/> that represents the asynchronous operation,
        /// an <see cref="IQueryable{Follower}"/>.
        /// </returns>
        public IQueryable<Follower> GetFollowers();
        /// <summary>
        /// Gets a list of <see cref="Follower"/>'s.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/> that represents the asynchronous operation,
        /// an <see cref="IQueryable{Follower}"/>.
        /// </returns>
        public IQueryable<Follower> GetFollowing();
    }
}
