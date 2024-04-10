using HotelBookings.Core.Interfaces;

namespace HotelBookings.Infrastructure.Persistence.Repositories
{
    public class ServicoReserva : IServicoReserva
    {
        private readonly IReservaRepository _reservaRepository;
        private readonly IClienteRepository _clienteRepository;
        private readonly IReservaService _reservaService;

        public ServicoReserva(IReservaRepository reservaRepository, IClienteRepository clienteRepository, IReservaService reservaService)
        {
            _reservaRepository = reservaRepository;
            _clienteRepository = clienteRepository;
            _reservaService = reservaService;
        }

        public async Task ProcessarConfirmacaoReserva(int idReserva)
        {
            var reserva = await _reservaRepository.ObterPorId(idReserva);

            if (reserva != null)
            {
                if (reserva.StatusDaReserva == "Confirmada")
                {
                    Console.WriteLine("Esta reserva já foi confirmada anteriormente.");
                    return;
                }

                reserva.StatusDaReserva = "Confirmada";
                await _reservaRepository.Atualizar(reserva);

                var cliente = await _clienteRepository.ObterPorId(reserva.IDDoCliente);

                if (cliente != null)
                {
                    await _reservaService.EnviarEmailConfirmacaoReserva(cliente, reserva);
                    Console.WriteLine("E-mail de confirmação enviado com sucesso.");
                }
                else
                {
                    Console.WriteLine("Cliente não encontrado para enviar e-mail de confirmação.");
                }
            }
            else
            {
                Console.WriteLine("Reserva não encontrada.");
            }
        }
    }
}
