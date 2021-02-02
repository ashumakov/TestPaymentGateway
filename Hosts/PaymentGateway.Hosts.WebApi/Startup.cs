using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using PaymentGateway.Core.DataAccess.Context;
using PaymentGateway.Hosts.WebApi.Security;
using PaymentGateway.Hosts.WebApi.Settings;
using Serilog;

namespace PaymentGateway.Hosts.WebApi
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddApiVersioning(o => {
                o.ReportApiVersions = true;
                o.AssumeDefaultVersionWhenUnspecified = true;
                o.DefaultApiVersion = new ApiVersion(1, 0);
            });
            services.AddVersionedApiExplorer(o =>
            {
                o.GroupNameFormat = "'v'VVV";
                o.SubstituteApiVersionInUrl = true;
            });

            services.AddRepositories(Configuration);
            services.AddServices();

            services.AddAuthentication(options =>
                {
                    options.DefaultScheme
                        = AuthenticationSchemeConstants.ValidateHashAuthenticationScheme;
                })
                .AddScheme<ValidateHashAuthenticationSchemeOptions, ValidateHashAuthenticationHandler>
                    (AuthenticationSchemeConstants.ValidateHashAuthenticationScheme, op => { });

            services.AddMapper();

            services.AddHealthChecks()
                .AddDbContextCheck<GatewayContext>();

            services.AddSwagger(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider provider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseCors("PublicPolicy");
            app.UseStatusCodePages();
            app.UseHttpsRedirection();
            app.UseApiVersioning();
            app.InitSwagger(Configuration, provider);

            app.UseSerilogRequestLogging();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHealthChecks("/health", new HealthCheckOptions()
                {
                    AllowCachingResponses = false
                });

                endpoints.MapControllers();
            });
        }
    }
}
