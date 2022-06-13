using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialMedia.Core.Entities;

namespace SocialMedia.Infrastructure.Data.Configs
{
    /// <summary>
    /// Configuration for <see cref="Post"/> entity.
    /// </summary>
    internal class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.HasOne(options => options.User)
                .WithMany(options => options.Posts)
                .HasForeignKey(options => options.UserId);

            builder.HasMany(options => options.Comments)
                .WithOne(options => options.Post)
                .HasForeignKey(options => options.PostId);
        }
    }
}
