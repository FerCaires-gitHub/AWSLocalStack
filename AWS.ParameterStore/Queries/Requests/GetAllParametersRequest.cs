using System.Collections.Generic;
using AWS.ParameterStore.Interfaces;

namespace AWS.ParameterStore.Queries.Request
{
    public class GetAllParametersRequest:IRequest
    {
        public List<string> Names { get; set; }
    }
}