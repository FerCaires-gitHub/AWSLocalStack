using System.Threading.Tasks;

namespace AWS.SQS.Interfaces
{
    public interface ISQSService
    {
        Task GetQueues(string prefix);

        Task CreateQueue(string queueName);
    }
}