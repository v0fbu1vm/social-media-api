using SocialMedia.Core.Entities;

namespace SocialMedia.GraphQL.Types
{
    /// <summary>
    /// Defining types for <see cref="Post"/>. This helps define the schema.
    /// </summary>
    public class PostType : ObjectType<Post>
    {
        protected override void Configure(IObjectTypeDescriptor<Post> descriptor)
        {
            descriptor.Description("Represents a Post.");

            descriptor.Field(instance => instance.Id)
                .Description("Represents a unique identifier.");

            descriptor.Field(instance => instance.DateCreated)
                .Description("Represents when a record was added to the system.");

            descriptor.Field(instance => instance.DateModified)
                .Description("Represents when a record was modified.");

            descriptor.Field(instance => instance.Caption)
                .Description("Represents a short caption.");

            descriptor.Field(instance => instance.Description)
                .Description("Represents a short description of the post.");

            descriptor.Field(instance => instance.FileName)
                .Description("Represents the name of the file.");

            descriptor.Field(instance => instance.UserId)
                .Description("Represents the id of the user that shared this post.");

            descriptor.Field(instance => instance.User)
                .Description("Represents the user that shared this post.")
                .Ignore();

            descriptor.Field(instance => instance.Comments)
                .Description("Represents a list of comments made on this post.")
                .Ignore();

            base.Configure(descriptor);
        }
    }
}