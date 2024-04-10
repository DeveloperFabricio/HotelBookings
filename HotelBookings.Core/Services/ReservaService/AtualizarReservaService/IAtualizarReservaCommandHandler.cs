using MediatR;

namespace HotelBookings.Core.Services.ReservaService.AtualizarReservaService
{
    public interface IAtualizarReservaCommandHandler
    {
        Task<Unit> Handle(IAtualizarReservaCommand command, CancellationToken cancellationToken);
    }
}
