using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using SocialMedia.Infrastructure.Data;
using System.Security.Claims;

namespace SocialMedia.Infrastructure.Services
{
    /// <summary>
    /// Represents a unique abstract service that holds common functionalities,
    /// between different services.
    /// </summary>
    public abstract class AbstractService : IAsyncDisposable
    {
        protected readonly DatabaseContext _dbContext;
        protected readonly IHttpContextAccessor _contextAccessor;

        protected AbstractService(IDbContextFactory<DatabaseContext> dbContextFactory, IHttpContextAccessor contextAccessor)
        {
            _dbContext = dbContextFactory.CreateDbContext();
            _contextAccessor = contextAccessor;
        }
        /// <summary>
        /// Gets the id of the authenticated user.
        /// </summary>
        /// <returns>
        /// The id of the user.
        /// </returns>
        protected string UserId()
        {
            try
            {
                if (_contextAccessor.HttpContext?.User.Identity is not ClaimsIdentity identity) return string.Empty;
                IList<Claim> claim = identity.Claims.ToList();
                return claim[0].Value;
            }
            catch
            {
                return string.Empty;
            }
        }

        public ValueTask DisposeAsync()
        {
            GC.SuppressFinalize(this);
            return _dbContext.DisposeAsync();
        }
    }
}
