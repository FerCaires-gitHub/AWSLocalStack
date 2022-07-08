using System.Threading.Tasks;
using AWS.ParameterStore.Commands.Requests;
using AWS.ParameterStore.Interfaces;
using AWS.ParameterStore.Queries.Request;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AWS.Main
{
    [ApiController]
    [Route("v1/parameters")]
    public class ParameterStoreController : ControllerBase
    {
        private readonly ILogger<ParameterStoreController> _logger;
        private readonly ICreateParameterHandler _createParameterHandler;
        private readonly IGetParameterHandler _getParameterHandler;
        private readonly IGetAllParametersHandler _getAllParametersHandler;

        public ParameterStoreController(ILogger<ParameterStoreController> logger,
        ICreateParameterHandler createParameterHandler,
        IGetParameterHandler getParameterHandler,
        IGetAllParametersHandler getAllParametersHandler)
        {
            _logger = logger;
            _createParameterHandler = createParameterHandler;
            _getParameterHandler = getParameterHandler;
            _getAllParametersHandler = getAllParametersHandler;
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreateParameterRequest request)
        {
            try
            {
                var result = await _createParameterHandler.HandleAsync(request);
                return Ok(result);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        [HttpGet]
        [Route("{name}")]
        public async Task<ActionResult> GetParameter(string name)
        {
            try
            {
                var response = await _getParameterHandler.HandleAsync(new GetParameterRequest { ParameterName = name });
                return Ok(response);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        [HttpPost]
        [Route("all")]

        public async Task<ActionResult> GetAllParameter(GetAllParametersRequest request)
        {
            try
            {
                var response = await _getAllParametersHandler.HandleAsync(request);
                return Ok(response);
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }

}