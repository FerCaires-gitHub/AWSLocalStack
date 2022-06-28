using System.Text.Json;
using System.Threading.Tasks;
using Amazon.SQS;
using AWS.SQS.Interfaces;

namespace AWS.SQS.Services
{
    public class ProducerService : IProducerService
    {
        private readonly IAmazonSQS _sqsService;
        private const string QUEUE_NAME = "BaixasQueue";
        public ProducerService(IAmazonSQS sqsService)
        {
            _sqsService = sqsService;
        }
        public async Task SendMessageAsync(object msg)
        {
            var queueUrl = await _sqsService.GetQueueUrlAsync(QUEUE_NAME);
            var json = JsonSerializer.Serialize(msg);
            await _sqsService.SendMessageAsync(queueUrl.QueueUrl,json);
        }
    }

}