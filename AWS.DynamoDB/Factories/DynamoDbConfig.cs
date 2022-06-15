using Amazon.DynamoDBv2;
using AWS.DynamoDB.Interfaces;

namespace AWS.DynamoDB.Factories
{
    public class DynamoDbConfig : IDataConnectionConfig<AmazonDynamoDBConfig>
    {
        public AmazonDynamoDBConfig GetSettings()
        {
            var config = new AmazonDynamoDBConfig();
            config.ServiceURL = "http://localhost:8000";
            return config;
        }
    }
}