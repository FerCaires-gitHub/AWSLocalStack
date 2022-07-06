using System.Threading.Tasks;
using Amazon.SQS;
using AWS.SQS.Interfaces;

namespace AWS.SQS.Services
{
    public class SQSService : ISQSService
    {
        private readonly IAmazonSQS _sqsCliente;

        public SQSService(IAmazonSQS sqsCliente)
        {
            _sqsCliente = sqsCliente;
        }

        public async Task CreateQueue(string queueName)
        {
            try
            {
                await _sqsCliente.CreateQueueAsync(queueName);
            }
            catch (System.Exception ex)
            {
                
                throw ex;
            }
            
        }

        public async Task GetQueues(string prefix)
        {
            var queues = await _sqsCliente.ListQueuesAsync(prefix);
            foreach (var item in queues.QueueUrls)
            {
                System.Console.WriteLine(item);
            }
        }
    }

}