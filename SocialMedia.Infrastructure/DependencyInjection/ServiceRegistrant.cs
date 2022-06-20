using Azure.Storage.Blobs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SocialMedia.Core.Interfaces;
using SocialMedia.Infrastructure.Data;
using SocialMedia.Infrastructure.Helpers;
using SocialMedia.Infrastructure.Services;

namespace SocialMedia.Infrastructure.DependencyInjection
{
    /// <summary>
    /// Used for registring the remaining minor services.
    /// </summary>
    public class ServiceRegistrant : IServiceRegistrant
    {
        public void Register(IServiceCollection services, IConfiguration _)
        {
            services.AddHttpContextAccessor();
            services.AddDbContextFactory<DatabaseContext>(options => options.UseSqlServer(AppSettings.ConnectionStringSqlServer));

            services.AddSingleton(options => new BlobServiceClient(AppSettings.AzureBlobStorageConnectionString));
            services.AddSingleton<IStorageManager, StorageManager>();
            services.AddSingleton<IEmailSender, EmailSender>();
            services.AddSingleton<ITokenProvider, TokenProvider>();

            services.AddTransient<IAuthService, AuthService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IFollowerService, FollowerService>();
            services.AddTransient<IPostService, PostService>();
            services.AddTransient<ICommentService, CommentService>();
        }
    }
}
