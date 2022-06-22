using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using SocialMedia.Core.Entities;
using SocialMedia.Core.Enums;
using SocialMedia.Core.Extensions;
using SocialMedia.Core.Interfaces;
using SocialMedia.Core.Models.Message;
using SocialMedia.Core.Objects;
using SocialMedia.Infrastructure.Data;

namespace SocialMedia.Infrastructure.Services
{
    /// <summary>
    /// A service for message related operation.
    /// </summary>
    public class MessageService : AbstractService, IMessageService
    {
        public MessageService(IDbContextFactory<DatabaseContext> dbContextFactory, IHttpContextAccessor contextAccessor) : base(dbContextFactory, contextAccessor)
        {
        }

        #region MessageAsync
        /// <inheritdoc cref="IMessageService.MessageAsync(CreateMessageRequest)"/>
        /// <remarks>
        /// May produce the following errors.
        /// <list type="bullet">
        /// <item><see cref="ErrorType.Problem"/></item>
        /// <item><see cref="ErrorType.NotFound"/></item>
        /// <item><see cref="ErrorType.BadRequest"/></item>
        /// </list>
        /// </remarks>
        public async Task<Result<Message>> MessageAsync(CreateMessageRequest request)
        {
            var validator = new CreateMessageValidator();
            var validationResult = validator.Validate(request);

            if (validationResult.IsValid)
            {
                var userExists = await _dbContext.Users.AnyAsync(options => options.Id == request.RecipientId);
                if (userExists)
                {
                    try
                    {
                        var message = new Message()
                        {
                            Content = request.Message,
                            SenderId = UserId(),
                            RecipientId = request.RecipientId
                        };

                        _dbContext.Messages.Add(message);
                        await _dbContext.SaveChangesAsync();

                        return Result<Message>.Success(message);
                    }
                    catch (Exception)
                    {
                        return Result<Message>.Failure(ErrorType.Problem, "Something unexpected occurred.");
                    }
                }

                return Result<Message>.Failure(ErrorType.NotFound, "Recipient not found.");
            }

            return Result<Message>.Failure(ErrorType.BadRequest, validationResult.ErrorMessage());
        }
        #endregion
    }
}
