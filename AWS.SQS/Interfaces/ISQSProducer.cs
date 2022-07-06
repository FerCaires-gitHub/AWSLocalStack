using System.Threading.Tasks;

namespace AWS.SQS.Interfaces
{
    public interface ISQSProducer
    {
        Task SendMessageAsync<T>(T source,string queueName) where T:class;
    }
    
}