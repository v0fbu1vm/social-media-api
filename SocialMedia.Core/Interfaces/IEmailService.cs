using SocialMedia.Core.Models.Mail;

namespace SocialMedia.Core.Interfaces
{
    public interface IEmailService
    {
        /// <summary>
        /// Used for sending an email messsage.
        /// </summary>
        /// <param name="message">Represents an email message that can be sent using any smtp client.</param>
        /// <returns></returns>
        public Task SendEmailAsync(MailMessage mailMessage);
    }
}
