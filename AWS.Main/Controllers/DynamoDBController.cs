using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AWS.Main
{
    [ApiController]
    public class DynamoDBController : ControllerBase
    {
        private readonly ILogger<DynamoDBController> _logger;

        public DynamoDBController(ILogger<DynamoDBController> logger)
        {
            _logger = logger;
        }
    }
    
}