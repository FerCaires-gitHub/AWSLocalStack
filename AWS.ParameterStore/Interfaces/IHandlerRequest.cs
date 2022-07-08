using System.Threading.Tasks;

namespace AWS.ParameterStore.Interfaces
{
    public interface IHandlerRequest< IRequest,IResponse>
    {
        Task<IResponse> HandleAsync(IRequest request);
    }
}