using Volo.Abp.AspNetCore.Serilog;
using Volo.Abp.Modularity;

namespace StockAppAbp.Shared.Hosting.AspNetCore
{
    [DependsOn(
        typeof(StockAppAbpSharedHosting),
        typeof(AbpAspNetCoreSerilogModule)
    )]
    public class StockAppAbpSharedHostingAspNetCore : AbpModule
    {

    }
}
