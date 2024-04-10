using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookings.Core.Services.ReservaService.CriarReservaService
{
    public interface ICriarReservaCommandHandler
    {
        Task<Unit> Handle(ICriarReservaCommand command, CancellationToken cancellationToken);
    }
}
