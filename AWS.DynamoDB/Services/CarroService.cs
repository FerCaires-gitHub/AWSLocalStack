using System.Collections.Generic;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DocumentModel;
using AWS.DynamoDB.Domain;
using AWS.DynamoDB.Interfaces;
using System;
using System.Threading.Tasks;

namespace AWS.DynamoDB.Services
{
    public class CarroService : ICarroService
    {
        private readonly IDataConnectionFactory<AmazonDynamoDBClient> _factory;

        public CarroService(IDataConnectionFactory<AmazonDynamoDBClient> factory)
        {
            _factory = factory;
        }
        public async Task<string> Create(Carro carro)
        {
            var client = _factory.GetConnection();
            Table table = Table.LoadTable(client, "Carros");
            var dictionary = new Dictionary<string, DynamoDBEntry>();
            var document = new Document();
            document["VIN"] = carro.Vin;
            document["Marca"] = carro.Marca;
            document["Ano"] = carro.Ano.ToShortDateString();
            await table.PutItemAsync(document);
            return string.Empty;
        }

        public async Task<Carro> Get(string id)
        {
            var client = _factory.GetConnection();
            Table table = Table.LoadTable(client, "Carros");
            var document = await table.GetItemAsync(id);
            if (document == null)
                return null;
            var carro = new Carro
            {
                Vin = document["VIN"],
                Ano = Convert.ToDateTime(document["Ano"]),
                Marca = document["Marca"]
            };
            return carro;
        }
    }
}