using System.Threading.Tasks;
using AWS.DynamoDB.Interfaces;
using AWS.DynamoDB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AWS.Main
{
    [ApiController]
    [Route("v1/DynamoDB")]
    public class DynamoDBController : ControllerBase
    {
        private readonly ILogger<DynamoDBController> _logger;
        private readonly IDynamoDBService<Usuario> _service;
        private readonly IDynamoDBTableService _tableService;

        public DynamoDBController(ILogger<DynamoDBController> logger, IDynamoDBService<Usuario> service, IDynamoDBTableService tableService)
        {
            _logger = logger;
            _service = service;
            _tableService = tableService;
        }

        [HttpGet]
        [Route("usuario")]
        public async Task<ActionResult> GetItem(string id)
        {
            try
            {
                var response = await _service.GetItem(id);
                return Ok(response);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        [HttpGet]
        [Route("table/{tableName}")]
        public async Task<ActionResult> GetTableDescription(string tableName)
        {
            try
            {
                var response = await _tableService.GetTableDescription(tableName);
                return Ok(response);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        [HttpGet]
        [Route("table")]

        public async Task<ActionResult> GetTables()
        {
            try
            {
                var response = await _tableService.GetTables();
                return Ok(response);
            }
            catch (System.Exception)
            {

                throw;
            }
        }


        [HttpPost]
        [Route("usuario")]
        public async Task<ActionResult> PutItem([FromBody] Usuario usuario)
        {
            try
            {
                var response = await _service.PutItem(usuario);
                return Ok(response);
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }

}