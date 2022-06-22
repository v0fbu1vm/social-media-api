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
        /// Used for messaging a user.
        /// </summary>
        /// <param name="request">Represents the required data for creating a message.</param>
        /// <returns>
        /// The <see cref="Task"/> that represents the asynchronous operation.
        /// A <see cref="Result{Message}"/>, containing detailes of operation.
        /// </returns>
        public Task<Result<Message>> MessageAsync(CreateMessageRequest request);
    }
}
