using AWS.ParameterStore.Interfaces;

namespace AWS.ParameterStore.Queries.Request
{
    public class GetParameterRequest : IRequest
    {
        public string ParameterName { get; set; }
    }
}