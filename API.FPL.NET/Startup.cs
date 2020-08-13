using System.Net;
using System.Net.Http;
using FPL.NET.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace API.FPL.NET
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
            services.AddMvc();

            // Register the Swagger services
            services.AddSwaggerDocument(config =>
            {
                config.PostProcess = document =>
                {
                    document.Info.Version = "v1";
                    document.Info.Title = "FPL.NET";
                    document.Info.Description = "An API wrapper written in C# for Fantasy Premier League";
                    document.Info.TermsOfService = "None";
                    document.Info.Contact = new NSwag.OpenApiContact
                    {
                        Name = "Mike Pratt",
                        Email = string.Empty,
                        Url = "https://mikesjp.dev"
                    };
                    document.Info.License = new NSwag.OpenApiLicense
                    {
                        Name = "MIT",
                        Url = "https://example.com/license"
                    };
                };
            });

            // Register FPL.NET Services.
            services.AddScoped<UserEntryService>();
            services.AddScoped<AuthService>();
            services.AddScoped<ClassicLeagueService>();
            // services.AddSingleton<IHttpService, HttpService>();
            var httpClientHandler = new HttpClientHandler
            {
                CookieContainer = new CookieContainer(),
                UseCookies = true,
                UseDefaultCredentials = false
            };
            services.AddHttpClient<UserEntryService>()
                .ConfigurePrimaryHttpMessageHandler(() => httpClientHandler);
            services.AddHttpClient<AuthService>()
                .ConfigurePrimaryHttpMessageHandler(() => httpClientHandler);
            services.AddHttpClient<ClassicLeagueService>()
                .ConfigurePrimaryHttpMessageHandler(() => httpClientHandler);
            services.AddHealthChecks();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
                app.UseHttpsRedirection();
            }

            // Register the Swagger generator and the Swagger UI middlewares
            app.UseOpenApi();
            app.UseSwaggerUi3();
            app.UseRouting();
            app.UseEndpoints(endpoints => {
                endpoints.MapControllers();
                endpoints.MapHealthChecks("/health");
            });
        }
    }
}