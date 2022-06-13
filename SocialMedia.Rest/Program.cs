using SocialMedia.Core.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.RegisterServicesFromAssemblies(builder.Configuration);

var app = builder.Build();

app.UseSwagger();

app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
