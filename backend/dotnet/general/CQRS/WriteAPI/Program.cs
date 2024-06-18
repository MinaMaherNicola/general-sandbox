using Couchbase.Extensions.DependencyInjection;
using WriteAPI.DataAccess.Buckets;
using WriteAPI.DataAccess.Collections;
using WriteAPI.Services;

namespace WriteAPI;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddScoped<IRabbitMQService, RabbitMQService>();

        builder.Services
            .AddCouchbase(opt =>
            {
                var couchbaseSettings = builder.Configuration.GetRequiredSection("Couchbase");
                opt.ConnectionString = couchbaseSettings["Connection"];
                opt.UserName = couchbaseSettings["Username"];
                opt.Password = couchbaseSettings["Password"];
            })
            .AddCouchbaseBucket<ICqrsBucket>("Cqrs", b =>
            {
                b.AddScope("People")
                 .AddCollection<IUsersCollectionProvider>("Users");
            });

        builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
        
        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}