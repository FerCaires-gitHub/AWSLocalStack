using System.Threading.Tasks;

namespace AWS.DynamoDB.Interfaces
{
    public interface IDynamoDBService<T> where T:class
    {
        Task<string> PutItem(T source);
        Task<T> GetItem(string id);
    }
    
}