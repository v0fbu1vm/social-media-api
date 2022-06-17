using SocialMedia.Core.Entities;
using SocialMedia.Core.Interfaces;

namespace SocialMedia.GraphQL.Resolvers
{
    /// <summary>
    /// A resolver for <see cref="SocialMedia.Core.Entities.Follower"/> navigation properties.
    /// </summary>
    public class FollowerResolvers
    {
        public User? GetUser([Parent] Follower follower, [Service] IFollowerService service)
        {
            throw new NotImplementedException();
        }

        public User? GetFollowee([Parent] Follower follower, [Service] IFollowerService service)
        {
            throw new NotImplementedException();
        }
    }
}
