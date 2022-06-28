using System.Threading.Tasks;

namespace AWS.SQS.Interfaces
{
    public interface IProducerService
    {
        Task SendMessageAsync(object msg );
    }
    
}