using System.Collections.Generic;
using System.Threading.Tasks;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;
using AWS.DynamoDB.Interfaces;

namespace AWS.DynamoDB.Services
{
    public class DynamoDBTableService : IDynamoDBTableService
    {
        private readonly IAmazonDynamoDB _amazonDynamoDB;
        public DynamoDBTableService(IAmazonDynamoDB amazonDynamoDB)
        {
            _amazonDynamoDB = amazonDynamoDB;
        }
        public async Task<TableDescription> GetTableDescription(string tableName)
        {

            var response = await _amazonDynamoDB.DescribeTableAsync(new DescribeTableRequest { TableName = tableName });
            return response.Table;

        }

        public async Task<IEnumerable<string>> GetTables()
        {
            string lastEvaluatedTableName = null;
            var tables = new List<string>();
            do
            {
                var response = await _amazonDynamoDB.ListTablesAsync(new ListTablesRequest { Limit = 2, ExclusiveStartTableName = lastEvaluatedTableName });
                tables.AddRange(response.TableNames);
                lastEvaluatedTableName = response.LastEvaluatedTableName;
            } while (lastEvaluatedTableName != null);

            return tables;
        }
    }

}