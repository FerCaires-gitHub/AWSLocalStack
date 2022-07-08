using System.Collections.Generic;
using System.Threading.Tasks;
using Amazon.SimpleSystemsManagement;
using AWS.ParameterStore.Interfaces;
using AWS.ParameterStore.Queries.Request;
using AWS.ParameterStore.Queries.Responses;

namespace AWS.ParameterStore.Handlers
{
    public class GetAllParametersHandler : IGetAllParametersHandler
    {
        private readonly IAmazonSimpleSystemsManagement _client;

        public GetAllParametersHandler(IAmazonSimpleSystemsManagement client)
        {
            _client = client;
        }
        public async Task<GetAllParametersResponse> HandleAsync(GetAllParametersRequest request)
        {
            try
            {
                var result  = await _client.GetParametersAsync(new Amazon.SimpleSystemsManagement.Model.GetParametersRequest{Names = request.Names});
                var parameters = new GetAllParametersResponse{Parametros= new List<GetParameterResponse>()};
                foreach (var item in result.Parameters)
                {
                    parameters.Parametros.Add(new GetParameterResponse{ ParameterName = item.Name, ParameterValue = item.Value});
                }
                return parameters;
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }
    }
}