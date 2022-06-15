using Microsoft.OpenApi.Models;
using SocialMedia.Core.Interfaces;

namespace SocialMedia.Rest.DependencyInjection
{
    /// <summary>
    /// Registers Swagger UI.
    /// </summary>
    public class SwaggerRegistrant : IServiceRegistrant
    {
        public void Register(IServiceCollection services, IConfiguration _)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo()
                {
                    Title = "SocialMedia.Api",
                    Description = @"A social media api where you can interact with other people,
                                    by posting, commenting, following and messaging.",
                    Version = "v1",
                });

                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Authorization header. Using bearer scheme."
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                          new OpenApiSecurityScheme()
                          {
                                Reference = new OpenApiReference()
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                          },

                         Array.Empty<string>()
                    }
                });
            });
        }
    }
}
