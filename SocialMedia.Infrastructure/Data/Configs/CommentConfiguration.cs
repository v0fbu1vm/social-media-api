using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialMedia.Core.Entities;

namespace SocialMedia.Infrastructure.Data.Configs
{
    /// <summary>
    /// Configuration for <see cref="Comment"/> entity.
    /// </summary>
    internal class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasOne(options => options.User)
                .WithMany(options => options.Comments)
                .HasForeignKey(options => options.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(options => options.Post)
                .WithMany(options => options.Comments)
                .HasForeignKey(options => options.PostId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}