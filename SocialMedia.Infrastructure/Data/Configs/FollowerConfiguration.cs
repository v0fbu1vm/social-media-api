using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialMedia.Core.Entities;

namespace SocialMedia.Infrastructure.Data.Configs
{
    /// <summary>
    /// Configuration for <see cref="Follower"/> entity.
    /// </summary>
    internal class FollowerConfiguration : IEntityTypeConfiguration<Follower>
    {
        public void Configure(EntityTypeBuilder<Follower> builder)
        {
            builder.HasIndex(options => new { options.UserId, options.FolloweeId})
                .IsUnique();

            builder.HasOne(options => options.User)
                .WithMany(options => options.Followers)
                .HasForeignKey(options => options.UserId);

            builder.HasOne(options => options.Followee)
                .WithMany(options => options.Following)
                .HasForeignKey(options => options.FolloweeId);
        }
    }
}
