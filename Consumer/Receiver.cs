using System;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Consumer
{
    class Receiver
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory();
            using(var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare("BasicTest", false, false, false, null);
                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body;
                    string message = Encoding.UTF8.GetString(body.Span);
                    Console.WriteLine("Nagato received message: {0}...", message);
                };
                channel.BasicConsume("BasicTest", true, consumer);
                Console.WriteLine("Consumed the message, press enter to exit consumer");
                Console.ReadLine();
            }
                
        }
    }
}