using System;
using Confluent.Kafka;

namespace producer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(SendMessageByKafka("Uma mensagem"));
        }

        private static string SendMessageByKafka(string message)
        {
            var config = new ProducerConfig { BootstrapServers = "192.168.0.16:9092" };

            using (var producer = new ProducerBuilder<Null, string>(config).Build())
            {
                try
                {
                    var sendResult = producer.ProduceAsync("fila_pedido", new Message<Null, string> { Value = message }).GetAwaiter().GetResult();
                    return $"Mensagem '{sendResult.Value}' de '{sendResult.TopicPartitionOffset}'";
                }
                catch (ProduceException<Null, string> e)
                {
                    Console.WriteLine($"Delivery failed: {e.Error.Reason}");
                }
            }

            return string.Empty;
        }
    }
}
