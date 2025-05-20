using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Volo.Abp;

namespace StockAppAbp.Shared.Hosting.Gateways
{
    public static class YarpSwaggerUIBuilderExtensions
    {
        public static IApplicationBuilder UseSwaggerUIWithYarp(this IApplicationBuilder app,
            ApplicationInitializationContext context)
        {
            app.UseSwagger();
            return app;
        }
    }
}
