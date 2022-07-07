using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using SocialMedia.Core.Entities;
using SocialMedia.Core.Enums;
using SocialMedia.Core.Extensions;
using SocialMedia.Core.Interfaces;
using SocialMedia.Core.Models.Comment;
using SocialMedia.Core.Objects;
using SocialMedia.Infrastructure.Data;

namespace SocialMedia.Infrastructure.Services
{
    /// <summary>
    /// A service for comment related operation.
    /// </summary>
    public class CommentService : AbstractService, ICommentService
    {
        public CommentService(IDbContextFactory<DatabaseContext> dbContextFactory, IHttpContextAccessor contextAccessor) : base(dbContextFactory, contextAccessor)
        {
        }

        #region GetCommentsAsync

        /// <inheritdoc cref="ICommentService.GetCommentsAsync"/>
        public async Task<ICollection<Comment>> GetCommentsAsync()
        {
            return await _dbContext.Comments
                .Where(options => options.UserId == UserId())
                .OrderByDescending(options => options.DateCreated)
                .AsNoTracking()
                .ToListAsync();
        }

        #endregion GetCommentsAsync

        #region GetCommentsForPostAsync

        /// <inheritdoc cref="ICommentService.GetCommentsForPostAsync(string, int)"/>
        public async Task<ICollection<Comment>> GetCommentsForPostAsync(string postId, int amount)
        {
            return Guid.TryParse(postId, out _) && amount > 0 ? await _dbContext.Comments
                .Where(options => options.PostId == postId)
                .OrderByDescending(options => options.DateCreated)
                .Take(amount)
                .AsNoTracking()
                .ToListAsync() : new List<Comment>();
        }

        #endregion GetCommentsForPostAsync

        #region GetCommentByIdAsync

        /// <inheritdoc cref="ICommentService.GetCommentByIdAsync(string)"/>
        public async Task<Comment?> GetCommentByIdAsync(string id)
        {
            return Guid.TryParse(id, out _) ? await _dbContext.Comments
                .FindAsync(id) : null;
        }

        #endregion GetCommentByIdAsync

        #region CommentAsync

        /// <inheritdoc cref="ICommentService.CommentAsync(CreateCommentRequest)"/>
        /// <remarks>
        /// May produce the following errors.
        /// <list type="bullet">
        /// <item><see cref="ErrorType.Problem"/></item>
        /// <item><see cref="ErrorType.NotFound"/></item>
        /// <item><see cref="ErrorType.BadRequest"/></item>
        /// </list>
        /// </remarks>
        public async Task<Result<Comment>> CommentAsync(CreateCommentRequest request)
        {
            var validator = new CreateCommentValidator();
            var validationResult = validator.Validate(request);

            if (validationResult.IsValid)
            {
                var postExits = await _dbContext.Posts.AnyAsync(options => options.Id == request.PostId);
                if (postExits)
                {
                    try
                    {
                        var comment = new Comment()
                        {
                            Content = request.Comment,
                            PostId = request.PostId,
                            UserId = UserId()
                        };

                        _dbContext.Comments.Add(comment);
                        await _dbContext.SaveChangesAsync();

                        return Result<Comment>.Success(comment);
                    }
                    catch (Exception)
                    {
                        return Result<Comment>.Failure(ErrorType.Problem, "Something unexpected occurred.");
                    }
                }

                return Result<Comment>.Failure(ErrorType.NotFound, "Post not found.");
            }

            return Result<Comment>.Failure(ErrorType.BadRequest, validationResult.ErrorMessage());
        }

        #endregion CommentAsync

        #region UpdateCommentAsync

        /// <inheritdoc cref="ICommentService.UpdateCommentAsync(string, UpdateCommentRequest)"/>
        /// <remarks>
        /// May produce the following errors.
        /// <list type="bullet">
        /// <item><see cref="ErrorType.NotFound"/></item>
        /// <item><see cref="ErrorType.BadRequest"/></item>
        /// </list>
        /// </remarks>
        public async Task<Result<Comment>> UpdateCommentAsync(string id, UpdateCommentRequest request)
        {
            var validator = new UpdateCommentValidator();
            var validationResult = validator.Validate(request);

            if (validationResult.IsValid)
            {
                if (Guid.TryParse(id, out _) && id == request.Id)
                {
                    var comment = await _dbContext.Comments.FirstOrDefaultAsync(options => options.Id == id && options.UserId == UserId());

                    if (comment != null)
                    {
                        comment.Content = request.Comment;
                        comment.DateModified = DateTime.UtcNow;

                        await _dbContext.SaveChangesAsync();
                        return Result<Comment>.Success(comment);
                    }

                    return Result<Comment>.Failure(ErrorType.NotFound, "Comment not found.");
                }

                return Result<Comment>.Failure(ErrorType.BadRequest, "Invalid id.");
            }

            return Result<Comment>.Failure(ErrorType.BadRequest, validationResult.ErrorMessage());
        }

        #endregion UpdateCommentAsync

        #region DeleteCommentAsync

        /// <inheritdoc cref="ICommentService.DeleteCommentAsync(string)"/>
        /// <remarks>
        /// May produce the following errors.
        /// <list type="bullet">
        /// <item><see cref="ErrorType.NotFound"/></item>
        /// <item><see cref="ErrorType.BadRequest"/></item>
        /// </list>
        /// </remarks>
        public async Task<Result<bool>> DeleteCommentAsync(string id)
        {
            if (Guid.TryParse(id, out _))
            {
                var comment = await _dbContext.Comments.FirstOrDefaultAsync(options => options.Id == id && options.UserId == UserId());
                if (comment != null)
                {
                    _dbContext.Comments.Remove(comment);
                    await _dbContext.SaveChangesAsync();

                    return Result<bool>.Success(true);
                }

                return Result<bool>.Failure(ErrorType.NotFound, "Comment not found.");
            }

            return Result<bool>.Failure(ErrorType.BadRequest, "Invalid input.");
        }

        #endregion DeleteCommentAsync
    }
}