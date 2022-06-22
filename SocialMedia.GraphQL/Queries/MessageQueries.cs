using HotChocolate.AspNetCore.Authorization;
using SocialMedia.Core.Entities;
using SocialMedia.Core.Interfaces;

namespace SocialMedia.GraphQL.Queries
{
    [ExtendObjectType(OperationTypeNames.Query)]
    public class MessageQueries
    {
        #region GetMessageAsync
        /// <summary>
        /// Used for getting a message.
        /// </summary>
        /// <param name="id">Represents the id of the message.</param>
        /// <param name="service">A service for <see cref="Message"/> related operations.</param>
        /// <returns>
        /// The <see cref="Task"/> that represents the asynchronous operation,
        /// a <see cref="Message"/>.
        /// </returns>
        [Authorize]
        public async Task<Message?> GetMessageAsync(string id, [Service] IMessageService service)
        {
            return await service.GetMessageByIdAsync(id);
        }
        #endregion

        #region GetMessagesSentToAsync
        /// <summary>
        /// Used for getting a list of messages sent to a specified user.
        /// </summary>
        /// <param name="userId">Represents the id of the user.</param>
        /// <param name="service">A service for <see cref="Message"/> related operations.</param>
        /// <returns>
        /// The <see cref="Task"/> that represents the asynchronous operation,
        /// An <see cref="ICollection{Message}"/>.
        /// </returns>
        [Authorize]
        public async Task<ICollection<Message>> GetMessagesSentToAsync(string userId, [Service] IMessageService service)
        {
            return await service.GetMessagesSentToAsync(userId);
        }
        #endregion

        #region GetMessagesReceivedFromAsync
        /// <summary>
        /// Used for getting a list of messages received from a specified user.
        /// </summary>
        /// <param name="userId">Represents the id of the user.</param>
        /// <param name="service">A service for <see cref="Message"/> related operations.</param>
        /// <returns>
        /// The <see cref="Task"/> that represents the asynchronous operation,
        /// An <see cref="ICollection{Message}"/>.
        /// </returns>
        [Authorize]
        public async Task<ICollection<Message>> GetMessagesReceivedFromAsync(string userId, [Service] IMessageService service)
        {
            return await service.GetMessagesReceivedFromAsync(userId);
        }
        #endregion
    }
}
