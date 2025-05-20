using Microsoft.Extensions.DependencyInjection;
using StockAppAbp.Shared.Hosting.AspNetCore;
using Volo.Abp.Modularity;

namespace StockAppAbp.Shared.Hosting.Gateways
{
 
    [DependsOn(
      typeof(StockAppAbpSharedHostingAspNetCoreModule)
     )]
    public class StockAppAbpSharedHostingGatewaysModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var configuration = context.Services.GetConfiguration();

            context.Services.AddHttpForwarderWithServiceDiscovery();

            context.Services.AddReverseProxy()
                .LoadFromConfig(configuration.GetSection("ReverseProxy"))
                .AddServiceDiscoveryDestinationResolver();
        }
    }
}
