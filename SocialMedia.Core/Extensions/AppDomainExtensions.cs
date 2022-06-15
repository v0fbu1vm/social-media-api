using System.Reflection;

namespace SocialMedia.Core.Extensions
{
    public static class AppDomainExtensions
    {
        /// <summary>
        /// Gets the entry and referenced assemblies.
        /// </summary>
        /// <param name="_">Represents an application domain.</param>
        /// <returns>
        /// A list of <see cref="Assembly"/>'s.
        /// </returns>
        public static IEnumerable<Assembly> GetEntryAndReferencedAssemblies(this AppDomain _)
        {
            Assembly? entryAssembly = Assembly.GetEntryAssembly();
            List<Assembly> assemblies = new List<Assembly>();

            entryAssembly?
            .GetReferencedAssemblies()
            .Where(options => options.FullName != null && options.FullName.Contains("SocialMedia"))
            .ToList()
            .ForEach(assemblyName => assemblies.Add(Assembly.Load(assemblyName)));

            if (entryAssembly != null) assemblies.Add(entryAssembly);

            return assemblies;
        }
    }
}
