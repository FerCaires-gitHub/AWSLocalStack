using System.Threading.Tasks;
using Amazon.SimpleSystemsManagement;
using AWS.ParameterStore.Interfaces;
using AWS.ParameterStore.Queries.Request;
using AWS.ParameterStore.Queries.Responses;

namespace AWS.ParameterStore.Handlers
{
    public class GetParameterHandler : IGetParameterHandler
    {
        private readonly IAmazonSimpleSystemsManagement _client;

        public GetParameterHandler(IAmazonSimpleSystemsManagement client)
        {
            _client = client;
        }
        public async Task<GetParameterResponse> HandleAsync(GetParameterRequest request)
        {
            var result  = await _client.GetParameterAsync(new Amazon.SimpleSystemsManagement.Model.GetParameterRequest{Name = request.ParameterName});
            return new GetParameterResponse{ ParameterName = result.Parameter.Name, ParameterValue = result.Parameter.Value};
        }
    }
}