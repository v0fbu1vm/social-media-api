using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using SocialMedia.Core.Entities;
using SocialMedia.Core.Enums;
using SocialMedia.Core.Interfaces;
using SocialMedia.Core.Models.Post;
using SocialMedia.Core.Objects;
using SocialMedia.Infrastructure.Data;

namespace SocialMedia.Infrastructure.Services
{
    /// <summary>
    /// A service for post related operation.
    /// </summary>
    public class PostService : AbstractService, IPostService
    {
        private readonly IStorageManager _storageManager;

        public PostService(IDbContextFactory<DatabaseContext> dbContextFactory, IHttpContextAccessor contextAccessor, IStorageManager storageManager) : base(dbContextFactory, contextAccessor)
        {
            _storageManager = storageManager;
        }

        #region PostAsync
        /// <inheritdoc cref="IPostService.PostAsync(CreatePostRequest)"/>
        public async Task<Result<Post>> PostAsync(CreatePostRequest request)
        {
            var validator = new CreatePostValidator();
            var validationResult = validator.Validate(request);

            if (validationResult.IsValid)
            {
                try
                {
                    var fileName = await _storageManager.UploadAsync(request.File);

                    var post = new Post()
                    {
                        Caption = request.Caption ?? string.Empty,
                        Description = request.Description ?? string.Empty,
                        UserId = UserId(),
                        FileName = fileName
                    };

                    _dbContext.Posts.Add(post);
                    await _dbContext.SaveChangesAsync();

                    return Result<Post>.Success(post);
                }
                catch (Exception)
                {
                    return Result<Post>.Failure(ErrorType.Problem, "Something unexpected occurred.");
                }
            }

            return Result<Post>.Failure(ErrorType.BadRequest, "Invalid input.");
        }
        #endregion
    }
}
