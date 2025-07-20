using Confluent.Kafka;
using System;
using System.Threading;

class Program
{
    private static void Main(string[] args)
    {
        var config = new ConsumerConfig
        {
            GroupId = "chat-consumer-group",
            BootstrapServers = "localhost:9092",
            AutoOffsetReset = AutoOffsetReset.Earliest
        };

        using var consumer = new ConsumerBuilder<Ignore, string>(config).Build();
        consumer.Subscribe("chat-messages");

        Console.WriteLine("=== Chat Consumer ===");

        while (true)
        {
            var result = consumer.Consume();
            Console.WriteLine(result.Message.Value);
        }
    }
}
