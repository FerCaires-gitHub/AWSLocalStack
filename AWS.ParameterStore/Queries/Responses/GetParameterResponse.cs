using AWS.ParameterStore.Interfaces;

namespace AWS.ParameterStore.Queries.Responses
{
    public class GetParameterResponse : IResponse
    {
        public string ParameterName { get; set; }
        public string ParameterValue { get; set; }
    }
}