using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Rewrite;
using StockAppAbp.Shared.Hosting.AspNetCore;
using StockAppAbp.Shared.Hosting.Gateways;
using Volo.Abp;
using Volo.Abp.Modularity;

namespace StockAppAbp.WebGateway
{
    [DependsOn(
        typeof(StockAppAbpSharedHostingAspNetCoreModule),
        typeof(StockAppAbpSharedHostingGatewaysModule)
    )]
    public class StockAppAbpWebGatewayModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var configuration = context.Services.GetConfiguration();
            var hostingEnvironment = context.Services.GetHostingEnvironment();

            SwaggerConfigurationHelper.ConfigureWithOidc(
                context: context,
                authority: configuration["AuthServer:Authority"]!,
                scopes:
                [
                    "IdentityService",  "OrderingService", "IventoryService"
                ],
                apiTitle: "Web Gateway API",
                discoveryEndpoint: configuration["AuthServer:MetadataAddress"]
            );

            context.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder
                        .WithOrigins(
                            configuration["App:CorsOrigins"]!
                                .Split(",", StringSplitOptions.RemoveEmptyEntries)
                                .Select(o => o.Trim().RemovePostFix("/"))
                                .ToArray()
                        )
                        .WithAbpExposedHeaders()
                        .SetIsOriginAllowedToAllowWildcardSubdomains()
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials();
                });
            });

            context.Services.AddMemoryCache();
        }

        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            var app = context.GetApplicationBuilder();
            var env = context.GetEnvironment();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCorrelationId();
            app.UseCors();
            app.UseAbpRequestLocalization();
            app.MapAbpStaticAssets();
            app.UseRouting();
            app.UseAuthorization();
            app.UseAbpSerilogEnrichers();

            app.UseRewriter(new RewriteOptions()
                // Regex for "", "/" and "" (whitespace)
                .AddRedirect("^(|\\|\\s+)$", "/swagger"));


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapReverseProxy();
            });

        }
    }
}
