using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookings.Core.Services.ReservaService.AtualizarReservaService
{
    public interface IAtualizarReservaCommand
    {
         int ReservaId { get; }
         int ClienteId { get; }
         int QuartoId { get; }
         DateTime DataCheckIn { get; }
         DateTime DataCheckOut { get; }
         int NumeroHospedes { get; }
    }
}
