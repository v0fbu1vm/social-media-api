using SocialMedia.Core.Interfaces;

namespace SocialMedia.GraphQL.DependencyInjection
{
    public class ServiceRegistrant : IServiceRegistrant
    {
        public void Register(IServiceCollection services, IConfiguration _)
        {
            services.AddGraphQLServer()
               .AddAuthorization()
               .AddDefaultTransactionScopeHandler()
               .AddQueryType()
               .AddMutationType()
               .AddProjections();
        }
    }
}
