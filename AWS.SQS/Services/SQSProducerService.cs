using System.Text.Json;
using System.Threading.Tasks;
using Amazon.SQS;
using AWS.SQS.Interfaces;

namespace AWS.SQS.Services
{
    public class SQSProducerService : ISQSProducer
    {
        private readonly IAmazonSQS _sqsCliente;
        private const string QUEUE_NAME = "BaixasQueue";

        public SQSProducerService(IAmazonSQS sqsCliente)
        {
            _sqsCliente = sqsCliente;
        }
        public async Task SendMessageAsync<T>(T source,string queueName) where T : class
        {
            try
            {
                var queueUrl = await _sqsCliente.GetQueueUrlAsync(queueName);
                await _sqsCliente.SendMessageAsync(queueUrl.QueueUrl, JsonSerializer.Serialize(source));
            }
            catch (System.Exception ex)
            {
                throw ex;
            }

        }
    }

}