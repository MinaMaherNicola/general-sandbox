using AlertsPoc.API.Extensions;
using AlertsPoc.Application;
using AlertsPoc.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

builder.Services
    .AddInfrastructure(builder.Configuration)
    .AddApplication(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

await app.MigrateDatabase();

app.UseHttpsRedirection();

await app.RunAsync();