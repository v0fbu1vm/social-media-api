using SocialMedia.Core.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.RegisterServicesFromAssemblies(builder.Configuration);

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapGraphQL();

app.MapGraphQLVoyager("graphql-voyager");

app.Run();
