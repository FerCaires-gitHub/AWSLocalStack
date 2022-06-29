using System.Collections.Generic;
using System.Threading.Tasks;
using Amazon.DynamoDBv2.Model;

namespace AWS.DynamoDB.Interfaces
{
    public interface IDynamoDBTableService
    {
        Task<IEnumerable<string>> GetTables();
        Task<TableDescription> GetTableDescription(string tableName);
    }
}