using Confluent.Kafka;

string topicName = "sinantok";

var config = new ConsumerConfig { GroupId = "messageConsumer", BootstrapServers = "localhost:9092", EnableAutoCommit = false };

using (var consumer = new ConsumerBuilder<Null, string>(config).Build())
{
    consumer.Subscribe(topicName);

    while (true)
    {
        var consumeResult = consumer.Consume();
        Console.WriteLine($"Received message at {consumeResult.TopicPartitionOffset}: {consumeResult.Value}");
        consumer.Commit();
    }
}