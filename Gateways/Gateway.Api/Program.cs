using Ocelot.DependencyInjection;
using Ocelot.Middleware;

namespace Gateway.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddAuthentication().AddJwtBearer("GatewayAuthenticationScheme", opt =>
            {
                opt.Authority = builder.Configuration["IdentityServerUrl"];
                opt.Audience = "resource_gateway";
                opt.RequireHttpsMetadata = false;
            });

            builder.Configuration.AddJsonFile($"configuration.{builder.Environment.EnvironmentName.ToLower()}.json").AddEnvironmentVariables();

            builder.Services.AddOcelot();

            

            var app = builder.Build();

  
            //app.MapGet("/", () => "Hello World!");
            app.UseOcelot().Wait();

            app.Run();
        }
    }
}
