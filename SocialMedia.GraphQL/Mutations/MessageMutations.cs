using HotChocolate.AspNetCore.Authorization;
using HotChocolate.Subscriptions;
using SocialMedia.Core.Entities;
using SocialMedia.Core.Enums;
using SocialMedia.Core.Interfaces;
using SocialMedia.Core.Models.Message;
using SocialMedia.Core.Objects;

namespace SocialMedia.GraphQL.Mutations
{
    [ExtendObjectType(OperationTypeNames.Mutation)]
    public class MessageMutations
    {
        #region MessageAsync
        /// <summary>
        /// Used for messaging a user.
        /// </summary>
        /// <param name="request">Represents the required data for creating a message.</param>
        /// <param name="service">A service for <see cref="Message"/> related operations.</param>
        /// <param name="sender">The topic event sender sends event messages to the pub/sub-system.</param>
        /// <returns>
        /// The <see cref="Task"/> that represents the asynchronous operation.
        /// A <see cref="Response{Message}"/>, containing detailes of operation.
        /// </returns>
        [Authorize]
        public async Task<Response<Message>> MessageAsync(CreateMessageRequest request, [Service] IMessageService service, [Service] ITopicEventSender sender)
        {
            var result = await service.MessageAsync(request);

            if (result.Succeeded)
            {
                await sender.SendAsync(request.RecipientId, result.Value);
                return Response<Message>.Created(result.Value);
            }

            return result.Fault.ErrorType switch
            {
                ErrorType.Problem => Response<Message>.Problem(result.Fault.ErrorMessage),
                ErrorType.NotFound => Response<Message>.NotFound(result.Fault.ErrorMessage),
                _ => Response<Message>.BadRequest(result.Fault.ErrorMessage)
            };
        }
        #endregion

        #region DeleteMessageAsync
        /// <summary>
        /// Used for deleting a message.
        /// </summary>
        /// <param name="id">Represents the id of the message.</param>
        /// <param name="service">A service for <see cref="Message"/> related operations.</param>
        /// <returns>
        /// The <see cref="Task"/> that represents the asynchronous operation.
        /// A <see cref="Response{bool}"/>, containing detailes of operation.
        /// </returns>
        [Authorize]
        public async Task<Response<bool>> DeleteMessageAsync(string id, [Service] IMessageService service)
        {
            var result = await service.DeleteMessageAsync(id);

            if (result.Succeeded)
            {
                return Response<bool>.NoContent(result.Value);
            }

            return result.Fault.ErrorType switch
            {
                ErrorType.NotFound => Response<bool>.NotFound(result.Fault.ErrorMessage),
                _ => Response<bool>.BadRequest(result.Fault.ErrorMessage)
            };
        }
        #endregion
    }
}
