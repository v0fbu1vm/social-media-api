using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SocialMedia.Core.Interfaces;
using System.Reflection;

namespace SocialMedia.Core.Extensions
{
    public static class ServiceRegistrantExtensions
    {
        /// <summary>
        /// An extension for registring services in assembly.
        /// </summary>
        /// <param name="services"></param>
        public static void RegisterServicesFromAssemblies(this IServiceCollection services, IConfiguration configuration)
        {
            var assemblies = AppDomain.CurrentDomain.GetEntryAndReferencedAssemblies();

            foreach (var assembly in assemblies)
            {
                var registrants = assembly.ExportedTypes.Where(x => typeof(IServiceRegistrant).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract).Select(Activator.CreateInstance).Cast<IServiceRegistrant>().ToList();

                registrants.ForEach(x => x.Register(services, configuration));
            }
        }
    }
}
