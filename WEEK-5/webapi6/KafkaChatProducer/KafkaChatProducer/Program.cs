using Confluent.Kafka;
using System;
using System.Threading.Tasks;

class Program
{
    private static async Task Main(string[] args)
    {
        var config = new ProducerConfig { BootstrapServers = "localhost:9092" };
        using var producer = new ProducerBuilder<Null, string>(config).Build();

        Console.WriteLine("Enter username:");
        var username = Console.ReadLine();

        while (true)
        {
            Console.Write($"{username}: ");
            var message = Console.ReadLine();

            if (message?.ToLower() == "exit") break;

            var chatMessage = $"[{DateTime.Now:HH:mm:ss}] {username}: {message}";
            await producer.ProduceAsync("chat-messages", new Message<Null, string> { Value = chatMessage });
        }
    }
}
