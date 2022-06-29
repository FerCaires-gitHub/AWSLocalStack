using System;
using Amazon.DynamoDBv2;
using AWS.DynamoDB.Interfaces;
using AWS.DynamoDB.Models;
using AWS.DynamoDB.Services;
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
            services.AddAWSService<IAmazonDynamoDB>();
            
            
            services.AddScoped<IDynamoDBService<Usuario>,UsuarioDynamoDBService>();
            services.AddScoped<IDynamoDBTableService,DynamoDBTableService>();
            
        }
    }
}
