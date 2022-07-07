using SocialMedia.Core.Entities;

namespace SocialMedia.GraphQL.Types
{
    /// <summary>
    /// Defining types for <see cref="Message"/>. This helps define the schema.
    /// </summary>
    public class MessageType : ObjectType<Message>
    {
        protected override void Configure(IObjectTypeDescriptor<Message> descriptor)
        {
            descriptor.Description("Represents a Message.");

            descriptor.Field(instance => instance.Id)
                .Description("Represents a unique identifier.");

            descriptor.Field(instance => instance.DateCreated)
                .Description("Represents when a record was added to the system.");

            descriptor.Field(instance => instance.DateModified)
                .Description("Represents when a record was modified.");

            descriptor.Field(instance => instance.Content)
                .Description("Represents the content of the message.");

            descriptor.Field(instance => instance.SenderId)
                .Description("Represents the id of the user that sent this message.");

            descriptor.Field(instance => instance.Sender)
                .Description("Represents the user that sent this message.")
                .Ignore();

            descriptor.Field(instance => instance.RecipientId)
                .Description("Represents the id of the user that received this message.");

            descriptor.Field(instance => instance.Recipient)
                .Description("Represents the user that received this message.")
                .Ignore();

            base.Configure(descriptor);
        }
    }
}