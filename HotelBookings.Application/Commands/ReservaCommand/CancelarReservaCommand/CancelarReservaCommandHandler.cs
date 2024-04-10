using HotelBookings.Core.Exceptions;
using HotelBookings.Core.Interfaces;
using HotelBookings.Core.Services.ReservaService.CancelarReservaService;
using MediatR;

namespace HotelBookings.Application.Commands.ReservaCommand.CancelarReservaCommand
{
    public class CancelarReservaCommandHandler : ICancelarReservaCommandHandler
    {
        private readonly IReservaRepository _reservaRepository;
        private readonly IMediator _mediator;

        public CancelarReservaCommandHandler(IReservaRepository reservaRepository, IMediator mediator)
        {
            _reservaRepository = reservaRepository;
            _mediator = mediator;
        }

        public async Task<Unit> Handle(ICancelarReservaCommand command, CancellationToken cancellationToken)
        {
            
            var reserva = await _reservaRepository.ObterPorId(command.ReservaId);
            if (reserva == null)
            {
                throw new NotFoundException("Reserva não encontrada");
            }

            
            reserva.StatusDaReserva = "Cancelada";

            
            await _reservaRepository.Remover(reserva);

            return Unit.Value;
        }

        
    }
}
