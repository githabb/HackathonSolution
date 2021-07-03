using RabbitMQ.Client;
using System;
using System.Text;
using System.Text.Json;

namespace Services.Messages
{
    public class MessageService : IMessageService
    {
        ConnectionFactory _factory;
        IConnection _conn;
        IModel _channel;

        public MessageService()
        {
            Console.WriteLine("about to connect to rabbit");

            _factory = new ConnectionFactory() { HostName = "rabbitmq", Port = 5672 };
            _factory.UserName = "guest";
            _factory.Password = "guest";
            _conn = _factory.CreateConnection();
            _channel = _conn.CreateModel();
            _channel.QueueDeclare(queue: "info",
                                    durable: false,
                                    exclusive: false,
                                    autoDelete: false,
                                    arguments: null);
        }

        public bool Enqueue(InfoMessage message)
        {
            var body = JsonSerializer.Serialize(message);
            _channel.BasicPublish(exchange: "",
                                routingKey: "info",
                                basicProperties: null,
                                body: Encoding.UTF8.GetBytes(body));

            Console.WriteLine(" [x] Published {0} to RabbitMQ", body);
            return true;
        }
    }
}
