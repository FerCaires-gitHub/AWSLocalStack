using System;

namespace AWS.SQS.Models
{
    public class SQSMessage
    {
        public string  Id { get; set; }
        public string Body { get; set; }
        public DateTime Data { get; set; }
    }
    
}