using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.OpenApi.Models;
using PaymentGateway.Hosts.WebApi.Security;
using Swashbuckle.AspNetCore.Filters;

namespace PaymentGateway.Hosts.WebApi.Settings
{
    public static class SwaggerRegister
    {
        public static void AddSwagger(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSwaggerGen(options =>
            {
                var provider = services.BuildServiceProvider().GetRequiredService<IApiVersionDescriptionProvider>();
                foreach (var description in provider.ApiVersionDescriptions)
                {
                    options.SwaggerDoc(description.GroupName, new OpenApiInfo
                    {
                        Title = $"Simple Payment Gateway API {description.ApiVersion}",
                        Version = description.ApiVersion.ToString(),
                        Description = $"{description.GroupName} Payment API."
                    });
                }

                options.IncludeXmlComments(GetXmlCommentsFilePath());
                options.OperationFilter<AppendAuthorizeToSummaryOperationFilter>();
                options.OperationFilter<SecurityRequirementsOperationFilter>(true, AuthenticationSchemeConstants.ValidateHashAuthenticationScheme);

                options.AddSecurityDefinition(AuthenticationSchemeConstants.ValidateHashAuthenticationScheme, new OpenApiSecurityScheme
                {
                    Description = "Standard Authorization header using the signature of the request body",
                    In = ParameterLocation.Header,
                    Name = AuthenticationSchemeConstants.HeaderName,
                    Type = SecuritySchemeType.ApiKey
                });
            });

        }

        public static void InitSwagger(this IApplicationBuilder builder, IConfiguration configuration, IApiVersionDescriptionProvider provider)
        {
            builder.UseSwagger();
            builder.UseSwaggerUI(
                options =>
                {
                    foreach (var description in provider.ApiVersionDescriptions)
                    {
                        //Domain URL is used if application is running after load balancer with routing rules
                        options.SwaggerEndpoint($"{configuration["DomainUrl"]}/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
                    }
                });
        }

        private static string GetXmlCommentsFilePath()
        {
            var basePath = PlatformServices.Default.Application.ApplicationBasePath;
            var fileName = typeof(Startup).GetTypeInfo().Assembly.GetName().Name + ".xml";
            return Path.Combine(basePath, fileName);
        }
    }
}
