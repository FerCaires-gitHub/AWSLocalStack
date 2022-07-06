using System.Threading.Tasks;

namespace AWS.SQS.Interfaces
{
    public interface ISQSConsumer
    {
        Task GetMessagesAsync<T>(string queueName);
    }
}