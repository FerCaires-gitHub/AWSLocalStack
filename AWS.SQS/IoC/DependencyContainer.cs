using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Amazon.SQS;
using AWS.SQS.Interfaces;
using AWS.SQS.Services;

namespace AWS.SQS.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            var options = configuration.GetAWSOptions();
            services.AddDefaultAWSOptions(options);
            services.AddAWSService<IAmazonSQS>();
            services.AddScoped<IProducerService, ProducerService>();
        }
    }
}