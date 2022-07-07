using SocialMedia.Core.Models;

namespace SocialMedia.Core.Interfaces
{
    /// <summary>
    /// An interface for email related operations.
    /// </summary>
    public interface IEmailSender
    {
        /// <summary>
        /// Used for sending an email messsage.
        /// </summary>
        /// <param name="mailMessage">Represents an email message that can be sent using any smtp client.</param>
        /// <returns>
        /// The <see cref="Task"/> that represents the asynchronous operation.
        /// </returns>
        public Task SendEmailAsync(MailMessage mailMessage);
    }
}