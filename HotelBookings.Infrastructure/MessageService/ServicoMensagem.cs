using HotelBookings.Core.Services;
using RabbitMQ.Client;

namespace HotelBookings.Infrastructure.MessageService
{
    public class ServicoMensagem : IServicoMensagem
    {
        private readonly ConnectionFactory _factory;

        public ServicoMensagem()
        {
            _factory = new ConnectionFactory
            {
                HostName = "localhost",
            };
        }
        public void Publicar(string queue, byte[] message)
        {
            using (var connection = _factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(
                        queue: queue,
                        durable: false,
                        exclusive: false,
                        autoDelete: false,
                        arguments: null);

                    channel.BasicPublish(
                        exchange: "",
                        routingKey: queue,
                        basicProperties: null,
                        body: message);
                }
            }
        }
    }
}
