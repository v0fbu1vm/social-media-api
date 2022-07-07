using SocialMedia.Core.Entities;

namespace SocialMedia.GraphQL.Types
{
    /// <summary>
    /// Defining types for <see cref="Follower"/>. This helps define the schema.
    /// </summary>
    public class FollowerType : ObjectType<Follower>
    {
        protected override void Configure(IObjectTypeDescriptor<Follower> descriptor)
        {
            descriptor.Description("Represents a follower.");

            descriptor.Field(instance => instance.Id)
                .Description("Represents a unique identifier.");

            descriptor.Field(instance => instance.TimeStamp)
                .Description("Represents when the message was sent.");

            descriptor.Field(instance => instance.UserId)
                .Description("Represents the id of the user that is following the other user.");

            descriptor.Field(instance => instance.User)
                .Description("Represents the user that is following the other user.")
                .Ignore();

            descriptor.Field(instance => instance.FolloweeId)
                .Description("Represents the id of the user that is being followed.");

            descriptor.Field(instance => instance.Followee)
                .Description("Represents the user that is being followed.")
                .Ignore();

            base.Configure(descriptor);
        }
    }
}