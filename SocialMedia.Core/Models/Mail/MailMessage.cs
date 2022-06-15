using System.Net.Mail;

namespace SocialMedia.Core.Models.Mail
{
    /// <summary>
    /// Represents an email message that can be sent using any smtp client.
    /// </summary>
    public class MailMessage
    {
        /// <summary>
        /// Represents a list of recipients.
        /// </summary>
        public ICollection<MailAddress> Recipients { get; set; } = new List<MailAddress>();
        /// <summary>
        /// Represents the subject of the mail.
        /// </summary>
        public string Subject { get; set; } = default!;
        /// <summary>
        /// Represents the body of the mail.
        /// </summary>
        public string Body { get; set; } = default!;
        /// <summary>
        /// Represents whether the body contains Html.
        /// </summary>
        public bool IsBodyHtml { get; set; } = false;
        /// <summary>
        /// A constructor requiring recipients emails as a string seperated by "," 
        /// </summary>
        /// <param name="recipients">A list of emails seperated by ",".</param>
        public MailMessage(string recipients)
        {
            recipients.Trim()
                .Split(',')
                .ToList()
                .ForEach(recipient =>
                {
                    MailAddress.TryCreate(recipient.Trim(), out MailAddress? result);
                    if (result != null) Recipients.Add(result);
                });
        }
    }
}
