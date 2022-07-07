using SocialMedia.Core.Entities;

namespace SocialMedia.GraphQL.Types
{
    /// <summary>
    /// Defining types for <see cref="Comment"/>. This helps define the schema.
    /// </summary>
    public class CommentType : ObjectType<Comment>
    {
        protected override void Configure(IObjectTypeDescriptor<Comment> descriptor)
        {
            descriptor.Description("Represents a Comment.");

            descriptor.Field(instance => instance.Id)
                .Description("Represents a unique identifier.");

            descriptor.Field(instance => instance.DateCreated)
                .Description("Represents when a record was added to the system.");

            descriptor.Field(instance => instance.DateModified)
                .Description("Represents when a record was modified.");

            descriptor.Field(instance => instance.Content)
                .Description("Represents the content of the comment.");

            descriptor.Field(instance => instance.UserId)
                .Description("Represents the id of the user that made this comment.");

            descriptor.Field(instance => instance.User)
                .Description("Represents the user that made this comment.")
                .Ignore();

            descriptor.Field(instance => instance.PostId)
                .Description("Represents the id of the post in which this comment was commented on.");

            descriptor.Field(instance => instance.Post)
                .Description("Represents the post in which this comment was commented on.")
                .Ignore();

            base.Configure(descriptor);
        }
    }
}