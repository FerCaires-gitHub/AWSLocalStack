using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Amazon.SQS;
using Amazon.SQS.Model;
using AWS.SQS.Domain;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace AWS.SQS.Workers
{
    public class ConsumerWorker : BackgroundService
    {
        private const string QUEUE_NAME = "BaixasQueue";
        private readonly IAmazonSQS _amazonSQS;
        private readonly ILogger<ConsumerWorker> _logger;

        public ConsumerWorker(IAmazonSQS amazonSQS, ILogger<ConsumerWorker> logger)
        {
            _amazonSQS = amazonSQS;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (true)
            {
                _logger.LogInformation($"Iniciando o processo de leitura das mensagens");
                var url = await _amazonSQS.GetQueueUrlAsync(QUEUE_NAME);
                var messages = await _amazonSQS.ReceiveMessageAsync(new ReceiveMessageRequest { QueueUrl = url.QueueUrl, MaxNumberOfMessages = 10 });
                _logger.LogInformation($"Foram encontradas {messages.Messages.Count} mensagens");
                foreach (var item in messages.Messages)
                {
                    var message = JsonSerializer.Deserialize<Usuario>(item.Body);
                    _logger.LogInformation($"Tratando usuário de id:{message.Id}");
                    await _amazonSQS.DeleteMessageAsync(new DeleteMessageRequest { QueueUrl = url.QueueUrl, ReceiptHandle = item.ReceiptHandle });
                }
                _logger.LogInformation("Processamento realizado com sucesso");
                await Task.Delay(5000);
            }
        }
    }
}