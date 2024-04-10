using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookings.Application.Commands.ReservaCommand.CriarReservaCommand
{
    public class CriarReservaCommand : IRequest<Unit>
    {
        public int ClienteId { get; set; }
        public int QuartoId { get; set; }
        public int ReservaId { get; set; }
        public DateTime DataCheckIn { get; set; }
        public DateTime DataCheckOut { get; set; }
        public int NumeroHospedes { get; set; }
    }
}
