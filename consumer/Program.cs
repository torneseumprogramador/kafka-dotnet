using System;
using Confluent.Kafka;

namespace consumer
{
    class Program
    {
        static void Main(string[] args)
        {
            StartConsumer();
        }

        private static void StartConsumer()
        {
            var conf = new ConsumerConfig
            {
                GroupId = "meu-consumer-grupo_1",
                BootstrapServers = "192.168.0.16:9092",
                AutoOffsetReset = AutoOffsetReset.Earliest
            };

            using (var c = new ConsumerBuilder<Ignore, string>(conf).Build())
            {
                Console.WriteLine($"---- Consumindo mensagens ----");

                c.Subscribe("fila_pedido");
                try
                {
                    while (true)
                    {
                        var result = c.Consume(1000);
                        if (result != null)
                        {
                            Console.WriteLine($"Mensagem: {result.Message.Value} recebida de {result.TopicPartitionOffset}");
                        }
                    }
                }
                catch (OperationCanceledException)
                {
                    c.Close();
                }
            }
        }
    }
}
