using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using System.Text;
using Microsoft.Extensions.Hosting;
using System.Text.Json;
using HotelBookings.Application.Models;
using HotelBookings.Core.Interfaces;
using HotelBookings.Application.Options;
using Microsoft.Extensions.Options;
using HotelBookings.Core.IntegrationEvents;

namespace HotelBookings.Application.Consumers
{
    public class ConsumidorReservaConfirmada : BackgroundService
    {
        private const string FILA_RESERVAS_CONFIRMADAS = "ReservasConfirmadas";
        private readonly IConnection _conexao;
        private readonly IModel _canal;
        private readonly IServiceProvider _provedorServicos;
        private readonly ConnectionFactory _connectionFactory;
        private readonly RabbitMqOptions _rabbitMqOptions;

        private readonly string _rabbitMqConnectionString;

        public ConsumidorReservaConfirmada(IServiceProvider provedorServicos, IOptions<RabbitMqOptions> rabbitMqOptions)
        {
            _provedorServicos = provedorServicos;
            _rabbitMqOptions = rabbitMqOptions.Value;

            if (string.IsNullOrEmpty(_rabbitMqOptions.UserName))
            {
                throw new ArgumentNullException(nameof(_rabbitMqOptions.UserName), "O nome de usuário do RabbitMQ é nulo ou vazio.");
            }

            var fabrica = new ConnectionFactory
            {
                HostName = _rabbitMqOptions.HostName,
                Port = _rabbitMqOptions.Port,
                UserName = _rabbitMqOptions.UserName,
                Password = _rabbitMqOptions.Password
            };

            _rabbitMqConnectionString = nameof(EventoEnviarEmail);

            _conexao = fabrica.CreateConnection();
            _canal = _conexao.CreateModel();

            _canal.QueueDeclare(
                queue: _rabbitMqConnectionString,
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null);
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var consumidor = new EventingBasicConsumer(_canal);

            consumidor.Received += async (sender, eventArgs) =>
            {
                var bytesReservaConfirmada = eventArgs.Body.ToArray();
                var jsonReservaConfirmada = Encoding.UTF8.GetString(bytesReservaConfirmada);

                var eventoReservaConfirmada = JsonSerializer.Deserialize<EventoReservaConfirmada>(jsonReservaConfirmada);

                await TratarReservaConfirmada(eventoReservaConfirmada);

                _canal.BasicAck(eventArgs.DeliveryTag, false);
            };

            _canal.BasicConsume(FILA_RESERVAS_CONFIRMADAS, false, consumidor);

            return Task.CompletedTask;
        }

        private async Task TratarReservaConfirmada(EventoReservaConfirmada eventoReservaConfirmada)
        {
            using (var escopo = _provedorServicos.CreateScope())
            {
                var servicoReserva = escopo.ServiceProvider.GetRequiredService<IServicoReserva>();

                await servicoReserva.ProcessarConfirmacaoReserva(eventoReservaConfirmada.IdReserva);
            }
        }
             
    
    }
}
