using AWS.ParameterStore.Interfaces;

namespace AWS.ParameterStore.Commands.Requests
{
    public class CreateParameterRequest : IRequest
    {
        public string ParameterName { get; set; }
        public string ParameterValue { get; set; }
    }
}