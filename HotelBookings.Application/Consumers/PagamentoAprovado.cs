using HotelBookings.Core.IntegrationEvents;
using HotelBookings.Core.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;

namespace HotelBookings.Application.Consumers
{
    public class PagamentoAprovado : BackgroundService
    {
        private const string PAGAMENTO_APROVADO_QUEUE = "Pagamento Aprovado";
        private readonly IConnection _connection;
        private readonly IModel _channel;
        private readonly IServiceProvider _serviceProvider;

        public PagamentoAprovado(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;


            var factory = new ConnectionFactory
            {
                HostName = "localhost",
            };

            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();

            _channel.QueueDeclare(
                queue: PAGAMENTO_APROVADO_QUEUE,
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null);
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var consumer = new EventingBasicConsumer(_channel);

            consumer.Received += async (sender, eventArgs) =>
            {
                var paymentApprovedBytes = eventArgs.Body.ToArray();
                var paymentApprovedJson = Encoding.UTF8.GetString(paymentApprovedBytes);

                var paymentApprovedIntegrationEvent = JsonSerializer.Deserialize<PagamentoAprovadoEvento>(paymentApprovedJson);

                await PagamentoFinalizado(paymentApprovedIntegrationEvent.IdPagamento);

                _channel.BasicAck(eventArgs.DeliveryTag, false);
            };

            _channel.BasicConsume(PAGAMENTO_APROVADO_QUEUE, false, consumer);

            return Task.CompletedTask;
        }

        public async Task PagamentoFinalizado(int id)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var pagamentoRepository = scope.ServiceProvider.GetRequiredService<IHotelRepository>();

                var pagamento = await pagamentoRepository.ObterPorId(id);

                pagamento.Finalizado();

                await pagamentoRepository.SavesChangesAsync();
            }
        }
    }
    
}
