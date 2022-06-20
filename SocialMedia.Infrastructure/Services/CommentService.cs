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
        #endregion

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
        #endregion

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
        #endregion
    }
}
