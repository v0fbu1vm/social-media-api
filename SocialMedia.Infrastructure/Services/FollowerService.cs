using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using SocialMedia.Core.Entities;
using SocialMedia.Core.Enums;
using SocialMedia.Core.Interfaces;
using SocialMedia.Core.Objects;
using SocialMedia.Infrastructure.Data;

namespace SocialMedia.Infrastructure.Services
{
    /// <summary>
    /// A service for follower related operation.
    /// </summary>
    public class FollowerService : AbstractService, IFollowerService
    {
        public FollowerService(IDbContextFactory<DatabaseContext> dbContextFactory, IHttpContextAccessor contextAccessor) : base(dbContextFactory, contextAccessor)
        {
        }

        #region FollowAsync
        /// <inheritdoc cref="IFollowerService.FollowAsync(string)"/>
        /// <remarks>
        /// May produce the following errors.
        /// <list type="bullet">
        /// <item><see cref="ErrorType.NotFound"/></item>
        /// <item><see cref="ErrorType.BadRequest"/></item>
        /// </list>
        /// </remarks>
        public async Task<Result<Follower>> FollowAsync(string userId)
        {
            if (Guid.TryParse(userId, out _) && userId != UserId())
            {
                var user = await _dbContext.Users.FindAsync(userId);
                if (user != null)
                {
                    try
                    {
                        var follower = new Follower()
                        {
                            UserId = UserId(),
                            FolloweeId = userId
                        };

                        _dbContext.Followers.Add(follower);
                        await _dbContext.SaveChangesAsync();

                        return Result<Follower>.Success(follower);
                    }
                    catch (Exception)
                    {
                        return Result<Follower>.Failure(ErrorType.BadRequest, "User is already being followed.");
                    }
                }

                return Result<Follower>.Failure(ErrorType.NotFound, "User not found.");
            }

            return Result<Follower>.Failure(ErrorType.BadRequest, "Invalid input.");
        }
        #endregion

        #region GetFolloweeAsync
        /// <inheritdoc cref="IFollowerService.GetFolloweeAsync(string)"/>
        public async Task<Follower?> GetFolloweeAsync(string userId)
        {
            return Guid.TryParse(userId, out _) ? await _dbContext.Followers.AsNoTracking()
                .FirstOrDefaultAsync(options => options.UserId == UserId() && options.FolloweeId == userId)
                : null;
        }
        #endregion

        #region GetFollowerAsync
        /// <inheritdoc cref="IFollowerService.GetFollowerAsync(string)"/>
        public async Task<Follower?> GetFollowerAsync(string userId)
        {
            return Guid.TryParse(userId, out _) ? await _dbContext.Followers.AsNoTracking()
                .FirstOrDefaultAsync(options => options.UserId == userId && options.FolloweeId == UserId())
                : null;
        }
        #endregion

        #region GetFollowers
        /// <inheritdoc cref="IFollowerService.GetFollowers"/>
        public IQueryable<Follower> GetFollowers()
        {
            return _dbContext.Followers.Where(options => options.FolloweeId == UserId())
                .AsNoTracking();
        }
        #endregion

        #region GetFollowing
        /// <inheritdoc cref="IFollowerService.GetFollowing"/>
        public IQueryable<Follower> GetFollowing()
        {
            return _dbContext.Followers.Where(options => options.UserId == UserId())
                .AsNoTracking();
        }
        #endregion

        #region UnFollowAsync
        /// <inheritdoc cref="IFollowerService.UnFollowAsync(string)"/>
        /// <remarks>
        /// May produce the following errors.
        /// <list type="bullet">
        /// <item><see cref="ErrorType.NotFound"/></item>
        /// <item><see cref="ErrorType.BadRequest"/></item>
        /// </list>
        /// </remarks>
        public async Task<Result<bool>> UnFollowAsync(string userId)
        {
            if (Guid.TryParse(userId, out _))
            {
                var follower = await _dbContext.Followers.FirstOrDefaultAsync(options => options.UserId == UserId() && options.FolloweeId == userId);
                if (follower != null)
                {
                    _dbContext.Followers.Remove(follower);
                    await _dbContext.SaveChangesAsync();

                    return Result<bool>.Success(true);
                }

                return Result<bool>.Failure(ErrorType.NotFound, "User not found.");
            }

            return Result<bool>.Failure(ErrorType.BadRequest, "Invalid input.");
        }
        #endregion
    }
}
