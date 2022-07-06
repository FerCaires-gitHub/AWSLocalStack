using System.Text.Json;
using System.Threading.Tasks;
using Amazon.SQS;
using Amazon.SQS.Model;
using AWS.SQS.Interfaces;
using Microsoft.Extensions.Logging;


namespace AWS.SQS.Services
{
    public class SQSConsumerService : ISQSConsumer
    {
        private const string QUEUE_NAME = "BaixasQueue";
        private readonly IAmazonSQS _sqsCliente;
        private readonly ILogger<SQSConsumerService> _logger;

        public SQSConsumerService(IAmazonSQS sqsCliente,ILogger<SQSConsumerService> logger)
        {
            _sqsCliente = sqsCliente;
            _logger = logger;
        }
        public async Task GetMessagesAsync<T>(string queueName)
        {
            var queueUrl = await _sqsCliente.GetQueueUrlAsync(queueName);
            var messages  = await _sqsCliente.ReceiveMessageAsync(new ReceiveMessageRequest{QueueUrl = queueUrl.QueueUrl, MaxNumberOfMessages = 10});
            foreach (var item in messages.Messages)
            {
                var message = JsonSerializer.Deserialize<T>(item.Body);
                _logger.LogInformation($"Tratando a mensage {message}");
                await _sqsCliente.DeleteMessageAsync(new DeleteMessageRequest { QueueUrl = queueUrl.QueueUrl, ReceiptHandle = item.ReceiptHandle });
            }
        }
    }
}