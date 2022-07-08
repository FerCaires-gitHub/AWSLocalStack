using AWS.ParameterStore.Queries.Request;
using AWS.ParameterStore.Queries.Responses;

namespace AWS.ParameterStore.Interfaces
{
    public interface IGetAllParametersHandler : IHandlerRequest<GetAllParametersRequest,GetAllParametersResponse>
    {
        
    }
}