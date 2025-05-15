using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace OrderingService.EntityFrameworkCore;

/* This class is needed for EF Core console commands
 * (like Add-Migration and Update-Database commands) */
public class OrderingServiceDbContextFactory : IDesignTimeDbContextFactory<OrderingServiceDbContext>
{
    public OrderingServiceDbContext CreateDbContext(string[] args)
    {
        var configuration = BuildConfiguration();
        
        OrderingServiceEfCoreEntityExtensionMappings.Configure();

        var builder = new DbContextOptionsBuilder<OrderingServiceDbContext>()
            .UseSqlServer(configuration.GetConnectionString("Default"));
        
        return new OrderingServiceDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../OrderingService.DbMigrator/"))
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
