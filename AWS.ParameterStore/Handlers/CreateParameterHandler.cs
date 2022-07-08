using System;
using System.Net;
using System.Threading.Tasks;
using Amazon.SimpleSystemsManagement;
using Amazon.SimpleSystemsManagement.Model;
using AWS.ParameterStore.Commands.Requests;
using AWS.ParameterStore.Commands.Responses;
using AWS.ParameterStore.Interfaces;


namespace AWS.ParameterStore.Handlers
{
    public class CreateParameterHandler : ICreateParameterHandler
    {
        private readonly IAmazonSimpleSystemsManagement _client;

        public CreateParameterHandler(IAmazonSimpleSystemsManagement client)
        {
            _client = client;
        }
        public async Task<CreateParameterResponse> HandleAsync(CreateParameterRequest request)
        {
            try
            {
                var result = await _client.PutParameterAsync(new PutParameterRequest{Type = ParameterType.String, Name = request.ParameterName, Value = request.ParameterValue });
            if(result.HttpStatusCode.Equals(HttpStatusCode.OK))
                return new CreateParameterResponse{Resultado = "Sucesso"};
            else
                return new CreateParameterResponse{Resultado = "Falha"};    
            }
            catch (Exception)
            {
                throw;
            }
            
        }
    }
}