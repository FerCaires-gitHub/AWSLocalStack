using System.Threading.Tasks;
using AWS.DynamoDB.Domain;
using AWS.DynamoDB.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AWS.DynamoDB.Controllers
{
    [ApiController]
    [Route("v1/carros")]
    public class CarroController : ControllerBase
    {
        private readonly ICarroService _service;

        public CarroController(ICarroService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] Carro request)
        {
            await _service.Create(request);
            return StatusCode(201, "Criado com sucesso");
        }

        [HttpGet]
        [Route("{vin}")]
        public async Task<ActionResult> Get([FromRoute] string vin)
        {
            var response = await _service.Get(vin);
            return Ok(response);
        }
    }
}