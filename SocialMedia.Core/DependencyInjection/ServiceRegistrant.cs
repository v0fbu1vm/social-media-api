using FluentValidation.AspNetCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SocialMedia.Core.Interfaces;
using System.Reflection;

namespace SocialMedia.Core.DependencyInjection
{
    /// <summary>
    /// Used for registring the remaining minor services.
    /// </summary>
    public class ServiceRegistrant : IServiceRegistrant
    {
        public void Register(IServiceCollection services, IConfiguration _)
        {
            services.AddFluentValidation(options => options.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly()));
        }
    }
}
