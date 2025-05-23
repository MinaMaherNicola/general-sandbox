using MultiTenant.API;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi()
    .AddModules(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapGet("/", () => "Hello World!");

app.Run();