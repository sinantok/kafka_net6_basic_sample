using Confluent.Kafka;

string topicName = "message_stream";

var config = new ProducerConfig() { BootstrapServers = "localhost:9092" };

using (var producer = new ProducerBuilder<Null, string>(config).Build())
{
    while (true)
    {
        Console.Write("Enter message: ");
        var text = Console.ReadLine();

        var result = producer.ProduceAsync(topicName, new Message<Null, string> { Value = text }).GetAwaiter().GetResult();

        Console.WriteLine($"Event sent on Partition: {result.Partition} with Offset: {result.Offset}");
    }

}