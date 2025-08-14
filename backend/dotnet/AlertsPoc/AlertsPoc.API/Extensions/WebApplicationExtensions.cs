using AlertsPoc.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using WebApplication = Microsoft.AspNetCore.Builder.WebApplication;

namespace AlertsPoc.API.Extensions;

public static class WebApplicationExtensions
{
    public static async Task<WebApplication> MigrateDatabase(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<AlertsDbContext>();
        
        var pending = await db.Database.GetPendingMigrationsAsync();
        
        if (db.Database.IsRelational() && pending.Any())
        {
            await db.Database.MigrateAsync();
        }

        return app;
    }
}