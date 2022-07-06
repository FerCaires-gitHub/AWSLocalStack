using System.Threading.Tasks;
using AWS.SQS.Interfaces;
using AWS.SQS.Models;
using Microsoft.AspNetCore.Mvc;

namespace AWS.Main
{
    [ApiController]
    [Route("v1/sqs")]
    public class SQSController : ControllerBase
    {
        private readonly ISQSProducer _producer;
        private readonly ISQSConsumer _consumer;
        private readonly ISQSService _sQSService;

        public SQSController(ISQSProducer producer, ISQSConsumer consumer, ISQSService sQSService)
        {
            _producer = producer;
            _consumer = consumer;
            _sQSService = sQSService;
        }

        [HttpPost]
        [Route("queues/{queue_name}")]
        public async Task<ActionResult> SendMessage([FromBody]SQSMessage message,string queue_name)
        {
            try
            {
                await _producer.SendMessageAsync<SQSMessage>(message,queue_name);
                return Ok();
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        [HttpGet]
        [Route("queues/{queue_name}")]
        public async Task<ActionResult> GetMessages(string queue_name)
        {
            try
            {
                await _consumer.GetMessagesAsync<SQSMessage>(queue_name);
                return Ok();
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        [HttpGet]
        [Route("queues")]
        public async Task<ActionResult> GetQueues(string prefix)
        {
            try
            {
                await _sQSService.GetQueues(prefix);
                return Ok();
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        [HttpPost]
        [Route("queues")]
        public async Task<ActionResult> CreateQueue(string prefix)
        {
            try
            {
                await _sQSService.CreateQueue(prefix);
                return Ok();
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}