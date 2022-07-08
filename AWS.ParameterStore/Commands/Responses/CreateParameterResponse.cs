using AWS.ParameterStore.Interfaces;

namespace AWS.ParameterStore.Commands.Responses
{
    public class CreateParameterResponse : IResponse
    {
        public string Resultado { get; set; }
    }
    
}