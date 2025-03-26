using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PersonalBloggingPlatform.Application;
using PersonalBloggingPlatform.Infrastructure;
using PersonalBloggingPlatform.Infrastructure.Configuration;
using PersonalBloggingPlatform.Infrastructure.Seeding;
using PersonalBloggingPlatform.Shared;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddShared();
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddControllers();
builder.Services.AddOpenApi();


// add JwtOptions configuring
builder.Services.Configure<JwtOptions>(
    builder.Configuration.GetSection("JwtOptions"));

builder.Services.AddJwtAuthentication(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseShared();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
await app.SeedAsync();
app.Run();
