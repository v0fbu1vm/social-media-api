using SocialMedia.Core.Entities;
using SocialMedia.Core.Models.Message;
using SocialMedia.Core.Objects;

namespace SocialMedia.Core.Interfaces
{
    /// <summary>
    /// An interface for message related operations.
    /// </summary>
    public interface IMessageService
    {
        /// <summary>
        /// Used for getting a message by id.
        /// </summary>
        /// <param name="id">Represents the id of the message.</param>
        /// <returns>
        /// The <see cref="Task"/> that represents the asynchronous operation,
        /// A <see cref="Message"/>.
        /// </returns>
        public Task<Message?> GetMessageByIdAsync(string id);

        /// <summary>
        /// Used for getting a list of messages sent to a specified user.
        /// </summary>
        /// <param name="userId">Represents the id of the user.</param>
        /// <returns>
        /// The <see cref="Task"/> that represents the asynchronous operation,
        /// An <see cref="ICollection{Message}"/>.
        /// </returns>
        public Task<ICollection<Message>> GetMessagesSentToAsync(string userId);

        /// <summary>
        /// Used for getting a list of messages received from a specified user.
        /// </summary>
        /// <param name="userId">Represents the id of the user.</param>
        /// <returns>
        /// The <see cref="Task"/> that represents the asynchronous operation,
        /// An <see cref="ICollection{Message}"/>.
        /// </returns>
        public Task<ICollection<Message>> GetMessagesReceivedFromAsync(string userId);

        /// <summary>
        /// Used for messaging a user.
        /// </summary>
        /// <param name="request">Represents the required data for creating a message.</param>
        /// <returns>
        /// The <see cref="Task"/> that represents the asynchronous operation.
        /// A <see cref="Result{Message}"/>, containing detailes of operation.
        /// </returns>
        public Task<Result<Message>> MessageAsync(CreateMessageRequest request);

        /// <summary>
        /// Used for deleting a message.
        /// </summary>
        /// <param name="id">Represents the id of the message.</param>
        /// <returns>
        /// The <see cref="Task"/> that represents the asynchronous operation.
        /// A <see cref="Result{bool}"/>, containing detailes of operation.
        /// </returns>
        public Task<Result<bool>> DeleteMessageAsync(string id);
    }
}