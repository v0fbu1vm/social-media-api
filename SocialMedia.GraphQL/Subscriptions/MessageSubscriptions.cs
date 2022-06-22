using HotChocolate.Execution;
using HotChocolate.Subscriptions;
using SocialMedia.Core.Entities;
using SocialMedia.Core.Interfaces;

namespace SocialMedia.GraphQL.Subscriptions
{
    [ExtendObjectType(OperationTypeNames.Subscription)]
    public class MessageSubscriptions
    {
        #region OnMessageReceivedAsync
        /// <summary>
        /// A method which users can subscribe to, in order to receive messages.
        /// </summary>
        /// <param name="token">Represents a token for authorization reasons.</param>
        /// <param name="receiver">Creates subscriptions to specific event topics.</param>
        /// <param name="tokenHandler">A service for token related operations.</param>
        /// <returns>
        /// Returns a <see cref="ISourceStream{Message}"/>
        /// for the given event topic.
        /// </returns>
        /// <exception cref="Exception"/>
        [SubscribeAndResolve]
        public async ValueTask<ISourceStream<Message>> OnMessageReceivedAsync(string token, [Service] ITopicEventReceiver receiver, [Service] ITokenHandler tokenHandler)
        {
            try
            {
                if (tokenHandler.IsTokenValid(token))
                {
                    var claim = tokenHandler.GetClaims(token).First(claim => claim.Type == "nameid");
                    return await receiver.SubscribeAsync<string, Message>(claim.Value);
                }

                throw new Exception("Token is invalid.");
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
