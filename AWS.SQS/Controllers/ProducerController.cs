using System.Threading.Tasks;
using AWS.SQS.Domain;
using AWS.SQS.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ProducerController
{
    [ApiController]
    [Route("v1/sqs")]
    public class ProducerController : ControllerBase
    {
        private readonly IProducerService _producerService;

        public ProducerController(IProducerService producerService )
        {
            _producerService = producerService;
        }

        [HttpPost]
        public async Task<ActionResult> PostMessage([FromBody] Usuario usuario)
        {
            try
            {
                await _producerService.SendMessageAsync(usuario);
                return Ok();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
    
}