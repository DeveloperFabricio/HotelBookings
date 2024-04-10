using HotelBookings.Application.Options;
using HotelBookings.Core.Entities;
using HotelBookings.Core.Interfaces;
using Microsoft.Extensions.Configuration;


namespace HotelBookings.Application.Services
{
    public class ReservaService : IReservaService
    {
        private readonly WebMailOptions _webMailOptions;
        private readonly IConfiguration _configuration;

        public ReservaService(WebMailOptions webMailOptions, IConfiguration configuration)
        {
            _webMailOptions = webMailOptions;
            _configuration = configuration;
        }

        public async Task EnviarEmailConfirmacaoReserva(Cliente cliente, Reserva reserva)
        {
            try
            {
                var emailEndPoint = _webMailOptions.EmailEndPoint;
                if (string.IsNullOrEmpty(emailEndPoint))
                {
                    Console.WriteLine("Configuração de ponto de extremidade de e-mail não definida.");
                    return;
                }

                var client = new HttpClient();
                client.BaseAddress = new Uri(emailEndPoint);

                var from = $"{_webMailOptions.Name} <{_webMailOptions.UrlBase}>";
                var to = $"{cliente.Nome} <{cliente.Email}>";
                var subject = "Confirmação de reserva";
                var body = $"Olá {cliente.Nome}, sua reserva foi confirmada.\n\nDetalhes da reserva:\n\n";
                body += $"Data de check-in: {reserva.DataDeCheckIn}\n";
                body += $"Data de check-out: {reserva.DataDeCheckOut}\n";
                body += $"Número de hóspedes: {reserva.NumeroDeHospedes}\n";
               

                var content = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("from", from),
                    new KeyValuePair<string, string>("to", to),
                    new KeyValuePair<string, string>("subject", subject),
                    new KeyValuePair<string, string>("body", body)
                });

                var response = await client.PostAsync("enviar-email", content);

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("E-mail de confirmação enviado com sucesso!");
                }
                else
                {
                    Console.WriteLine($"Erro ao enviar e-mail. StatusCode: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro ao enviar o e-mail: {ex.Message}");
            }
        }
    }
}
