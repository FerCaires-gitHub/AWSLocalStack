using Amazon.DynamoDBv2;
using AWS.DynamoDB.Factories;
using AWS.DynamoDB.Interfaces;
using AWS.DynamoDB.Services;
using Microsoft.Extensions.DependencyInjection;

namespace AWS.DynamoDB.IoC{

    public class DependencyContainer
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IDataConnectionConfig<AmazonDynamoDBConfig>,DynamoDbConfig>();
            services.AddScoped<IDataConnectionFactory<AmazonDynamoDBClient>, DynamoDBConnectionFactory>();
            services.AddScoped<ICarroService, CarroService>();
        }
        
    }
}