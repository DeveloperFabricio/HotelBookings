using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookings.Core.Services.ReservaService.CancelarReservaService
{
    public interface ICancelarReservaCommandHandler
    {
        Task<Unit> Handle(ICancelarReservaCommand command, CancellationToken cancellationToken);
    }
}
