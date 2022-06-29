using System.Text.Json;
using System.Threading.Tasks;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DocumentModel;
using Amazon.DynamoDBv2.Model;
using AWS.DynamoDB.Interfaces;
using AWS.DynamoDB.Models;

namespace AWS.DynamoDB.Services
{
    public class UsuarioDynamoDBService : IDynamoDBService<Usuario>
    {
        private readonly IAmazonDynamoDB _dynamoDB;

        public UsuarioDynamoDBService(IAmazonDynamoDB dynamoDB)
        {
            _dynamoDB = dynamoDB;
        }
        public async Task<Usuario> GetItem(string id)
        {
            var table = Table.LoadTable(_dynamoDB, typeof(Usuario).Name);
            var document = await table.GetItemAsync(id);
            var response = default(Usuario);
            if (document != null)
                response = JsonSerializer.Deserialize<Usuario>(document.ToJson());
            return response;
        }

        public async Task<string> PutItem(Usuario source)
        {
            source.Id = System.Guid.NewGuid().ToString();
            var table = Table.LoadTable(_dynamoDB, typeof(Usuario).Name);
            var document = CreateDocument(source);
            await table.PutItemAsync(document);
            return source.Id.ToString();
        }
        private Document CreateDocument(Usuario usuario)
        {
            var document = new Document();
            foreach (var item in typeof(Usuario).GetProperties())
            {
                document[item.Name] = item.GetValue(usuario).ToString();
            }
            return document;
        }
    }
}