using System;
using System.Text;
using RabbitMQ.Client;

namespace Producer
{
    class Sender
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare("BasicTest", false, false, false, null);
                string message = "Nagato getting started with .NET microservices";
                var body = Encoding.UTF8.GetBytes(message);
                channel.BasicPublish("","BasicTest", null, body);

                Console.WriteLine("Nagato sent a message... {0}", message);
                
            }

            Console.WriteLine("Press Enter to exit app...");
            Console.ReadLine();
        }
    }
}
