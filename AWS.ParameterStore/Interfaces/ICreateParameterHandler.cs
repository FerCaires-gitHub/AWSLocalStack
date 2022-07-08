using AWS.ParameterStore.Commands.Requests;
using AWS.ParameterStore.Commands.Responses;

namespace AWS.ParameterStore.Interfaces
{
    public interface ICreateParameterHandler : IHandlerRequest<CreateParameterRequest,CreateParameterResponse>
    {
        
    }
}