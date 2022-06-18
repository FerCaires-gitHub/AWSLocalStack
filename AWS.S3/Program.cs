using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


namespace AWS.S3
{
    class Program
    {
        static void Main(string[] args)
        {
            var host  = Host.CreateDefaultBuilder()
                        .ConfigureServices((context,services) => 
                        {
                            
                        }).Build();
        }
    }
}
