using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Volo.Abp.Modularity;

namespace StockAppAbp.Shared.Hosting.AspNetCore
{
    public static class JwtBearerConfigurationHelper
    {

        public static void Configure(ServiceConfigurationContext context,string audience)
        {
            var configuration = context.Services.GetConfiguration();


            context.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                 .AddJwtBearer(options =>
                 {
                     options.Authority = configuration["AuthServer:Authority"];
                     options.RequireHttpsMetadata = Convert.ToBoolean(configuration["AuthServer:RequireHttpsMetadata"]);
                     options.Audience = audience;
                     options.TokenValidationParameters = new TokenValidationParameters()
                     {
                         ValidIssuers = new[]{ configuration["AuthServer:Authority"], configuration["AuthServer:MetadataAddress"] },
                         SignatureValidator = delegate (string token, TokenValidationParameters parameters)
                         {
                             var jwt = new Microsoft.IdentityModel.JsonWebTokens.JsonWebToken(token);
                             return jwt;
                         }
                     };
                 });

        }
    }
}
