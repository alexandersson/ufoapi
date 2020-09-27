using System;
using GraphiQl;
using GraphQL;
using GraphQL.Server;
using GraphQL.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ufoapi.Data.EFCore;
using ufoapi.Entities;
using ufoapi.GraphQL;
using ufoapi.GraphQL.Queries;
using ufoapi.GraphQL.Types;

namespace ufoapi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<KestrelServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });
            services.AddScoped<SightingQuery>();
            services.AddScoped<SightingContext>();
            services.AddDbContext<SightingContext>(options =>
                options.UseSqlite("Data Source=sighting.db"));
            services.AddSingleton<Sighting>();
            services.AddSingleton<SightingType>();
            services.AddScoped<EfCoreSightingRepository>();
            services.AddSingleton<IDocumentExecuter, DocumentExecuter>();

            services.AddScoped<UfoSightingSchema>();
            services.AddScoped<ISchema, UfoSightingSchema>();
            services.AddGraphQL((options, provider) =>
                {

                    var logger = provider.GetRequiredService<ILogger<Startup>>();
                    options.UnhandledExceptionDelegate = ctx =>
                        logger.LogError("{Error} occured", ctx.OriginalException.Message);
                })
                // Add required services for de/serialization
                .AddSystemTextJson(deserializerSettings => { }, serializerSettings => { }); // For .NET Core 3+
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseRouting();
            app.UseGraphiQl();
            app.UseGraphQL<UfoSightingSchema>();
        }
    }
}
