using SocialMedia.Core.Interfaces;

namespace SocialMedia.Rest.DependencyInjection
{
    /// <summary>
    /// Used for registring the remaining minor services.
    /// </summary>
    public class ServiceRegistrant : IServiceRegistrant
    {
        public void Register(IServiceCollection services, IConfiguration _)
        {
            services.AddControllersWithViews();
            services.AddEndpointsApiExplorer();
            services.AddAutoMapper(typeof(MapperInitializer));
        }
    }
}