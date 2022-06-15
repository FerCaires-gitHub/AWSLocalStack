using System.Collections.Generic;
using System.Threading.Tasks;
using AWS.DynamoDB.Domain;

namespace AWS.DynamoDB.Interfaces
{
    public interface ICarroService
    {
        Task<string> Create(Carro carro);
        Task<Carro> Get(string id);
    }
}