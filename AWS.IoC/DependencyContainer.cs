using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AWS.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            var options = configuration.GetAWSOptions("Aws:Localstack");
            services.AddDefaultAWSOptions(options);
            
        }
    }
}
