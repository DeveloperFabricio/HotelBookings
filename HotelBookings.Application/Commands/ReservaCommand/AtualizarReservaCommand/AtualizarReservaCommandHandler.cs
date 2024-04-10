using HotelBookings.Core.Exceptions;
using HotelBookings.Core.Interfaces;
using HotelBookings.Core.Services.ReservaService.AtualizarReservaService;
using MediatR;

namespace HotelBookings.Application.Commands.ReservaCommand.AtualizarReservaCommand
{
    public class AtualizarReservaCommandHandler : IAtualizarReservaCommandHandler
    {
        private readonly IReservaRepository _reservaRepository;
        private readonly IMediator _mediator;

        public AtualizarReservaCommandHandler(IReservaRepository reservaRepository, IMediator mediator)
        {
            _reservaRepository = reservaRepository;
            _mediator = mediator;
        }

        public async Task<Unit> Handle(IAtualizarReservaCommand command, CancellationToken cancellationToken)
        {
            
            var reserva = await _reservaRepository.ObterPorId(command.ReservaId);
            if (reserva == null)
            {
                throw new NotFoundException("Reserva não encontrada");
            }

            
            reserva.DataDeCheckIn = command.DataCheckIn;
            reserva.DataDeCheckOut = command.DataCheckOut;
            reserva.NumeroDeHospedes = command.NumeroHospedes;

            
            await _reservaRepository.Atualizar(reserva);

            return Unit.Value;
        }

        
    }

}
