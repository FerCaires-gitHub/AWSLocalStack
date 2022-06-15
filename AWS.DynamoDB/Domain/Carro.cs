using System;

namespace AWS.DynamoDB.Domain
{
    public class Carro
    {
        public string Vin { get; set; }
        public string Marca { get; set; }
        public DateTime Ano { get; set; }
    }
    
}