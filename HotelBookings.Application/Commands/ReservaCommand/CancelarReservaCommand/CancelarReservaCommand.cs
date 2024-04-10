using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookings.Application.Commands.ReservaCommand.CancelarReservaCommand
{
    public class CancelarReservaCommand : IRequest<Unit>
    {
        public int ReservaId { get; set; }
    }
}
