using SocialMedia.Core.Interfaces;
using SocialMedia.GraphQL.Mutations;
using SocialMedia.GraphQL.Queries;
using SocialMedia.GraphQL.Types;

namespace SocialMedia.GraphQL.DependencyInjection
{
    /// <summary>
    /// Used for registring the remaining minor services.
    /// </summary>
    public class ServiceRegistrant : IServiceRegistrant
    {
        public void Register(IServiceCollection services, IConfiguration _)
        {
            services.AddGraphQLServer()
               .AddAuthorization()
               .AddDefaultTransactionScopeHandler()
               .AddQueryType()
               .AddMutationType()
               .AddTypeExtension<FollowerQueries>()
               .AddTypeExtension<FollowerMutations>()
               .AddTypeExtension<PostQueries>()
               .AddTypeExtension<PostMutations>()
               .AddTypeExtension<CommentMutations>()
               .AddType<FollowerType>()
               .AddType<PostType>()
               .AddProjections();
        }
    }
}
