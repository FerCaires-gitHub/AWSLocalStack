using System.Collections;
using System.Collections.Generic;
using AWS.ParameterStore.Interfaces;

namespace AWS.ParameterStore.Queries.Responses
{
    public class GetAllParametersResponse : IResponse
    {
        public IList<GetParameterResponse> Parametros { get; set; }
    }
}