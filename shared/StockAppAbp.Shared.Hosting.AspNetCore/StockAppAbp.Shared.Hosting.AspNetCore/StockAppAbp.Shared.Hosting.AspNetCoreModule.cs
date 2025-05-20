using Volo.Abp.AspNetCore.Serilog;
using Volo.Abp.Modularity;
using Volo.Abp.Swashbuckle;
using Volo.Abp.VirtualFileSystem;

namespace StockAppAbp.Shared.Hosting.AspNetCore
{
    [DependsOn(
        typeof(StockAppAbpSharedHostingModule),
        typeof(AbpAspNetCoreSerilogModule),
        typeof(AbpSwashbuckleModule)
    )]
    public class StockAppAbpSharedHostingAspNetCoreModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<StockAppAbpSharedHostingAspNetCoreModule>("StockAppAbp.Shared.Hosting.AspNetCore");
            });
        }
    }
}
