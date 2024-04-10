using HotelBookings.Core.Entities;
using HotelBookings.Core.Interfaces;
using HotelBookings.Core.Services.ReservaService.CriarReservaService;
using MediatR;

namespace HotelBookings.Application.Commands.ReservaCommand.CriarReservaCommand
{
    public class CriarReservaCommandHandler : ICriarReservaCommandHandler
    {
        private readonly IReservaRepository _reservaRepository;
        private readonly IMediator _mediator;

        public CriarReservaCommandHandler(IReservaRepository reservaRepository, IMediator mediator)
        {
            _reservaRepository = reservaRepository;
            _mediator = mediator;
        }

        public async Task<Unit> Handle(ICriarReservaCommand command, CancellationToken cancellationToken)
        {

            Reserva novaReserva = new Reserva
            {
                IDDoCliente = command.ClienteId,
                IDDoQuarto = command.QuartoId,
                DataDeCheckIn = command.DataCheckIn,
                DataDeCheckOut = command.DataCheckOut,
                NumeroDeHospedes = command.NumeroHospedes,
                StatusDaReserva = "Pendente"
            };

            _reservaRepository.Adicionar(novaReserva);

            await _reservaRepository.Adicionar(novaReserva);

            return Unit.Value;
        }
    }
}
