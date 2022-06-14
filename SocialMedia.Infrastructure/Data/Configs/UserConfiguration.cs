using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialMedia.Core.Entities;

namespace SocialMedia.Infrastructure.Data.Configs
{
    /// <summary>
    /// Configuration for <see cref="User"/> entity.
    /// </summary>
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasMany(options => options.MessagesSent)
                .WithOne(options => options.Sender)
                .HasForeignKey(options => options.SenderId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(options => options.MessagesReceived)
                .WithOne(options => options.Recipient)
                .HasForeignKey(options => options.RecipientId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(options => options.Posts)
                .WithOne(options => options.User)
                .HasForeignKey(options => options.UserId);

            builder.HasMany(options => options.Comments)
                .WithOne(options => options.User)
                .HasForeignKey(options => options.UserId);

            builder.HasMany(options => options.Followers)
                .WithOne(options => options.User)
                .HasForeignKey(options => options.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(options => options.Following)
                .WithOne(options => options.Followee)
                .HasForeignKey(options => options.FolloweeId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
