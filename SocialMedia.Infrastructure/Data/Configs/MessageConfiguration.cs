using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialMedia.Core.Entities;

namespace SocialMedia.Infrastructure.Data.Configs
{
    /// <summary>
    /// Configuration for <see cref="Message"/> entity.
    /// </summary>
    internal class MessageConfiguration : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            builder.HasOne(options => options.Sender)
                .WithMany(options => options.MessagesSent)
                .HasForeignKey(options => options.SenderId);

            builder.HasOne(options => options.Recipient)
                .WithMany(options => options.MessagesReceived)
                .HasForeignKey(options => options.RecipientId);
        }
    }
}