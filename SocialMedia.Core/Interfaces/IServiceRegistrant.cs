using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace SocialMedia.Core.Interfaces
{
    public interface IServiceRegistrant
    {
        public void Register(IServiceCollection services, IConfiguration configuration);
    }
}
