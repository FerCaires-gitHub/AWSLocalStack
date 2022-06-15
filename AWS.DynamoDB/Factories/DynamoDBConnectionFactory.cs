using Amazon.DynamoDBv2;
using AWS.DynamoDB.Interfaces;

namespace AWS.DynamoDB.Factories
{
    public class DynamoDBConnectionFactory : IDataConnectionFactory<AmazonDynamoDBClient>
    {
        private readonly IDataConnectionConfig<AmazonDynamoDBConfig> _config;

        public DynamoDBConnectionFactory(IDataConnectionConfig<AmazonDynamoDBConfig> config)
        {
            _config = config;
        }

        public AmazonDynamoDBClient GetConnection()
        {
            var client = new AmazonDynamoDBClient(_config.GetSettings());
            return client;
        }
    }
}