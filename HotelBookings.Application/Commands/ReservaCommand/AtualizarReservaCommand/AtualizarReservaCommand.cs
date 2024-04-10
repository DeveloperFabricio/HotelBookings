using MediatR;

namespace HotelBookings.Application.Commands.ReservaCommand.AtualizarReservaCommand
{
    public class AtualizarReservaCommand : IRequest<Unit>
    {
        public int ReservaId { get; set; }
        public int ClienteId { get; set; }
        public int QuartoId { get; set; }
        public DateTime DataCheckIn { get; set; }
        public DateTime DataCheckOut { get; set; }
        public int NumeroHospedes { get; set; }
    }
}
