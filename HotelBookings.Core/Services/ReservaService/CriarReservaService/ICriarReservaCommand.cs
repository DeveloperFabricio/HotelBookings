using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookings.Core.Services.ReservaService.CriarReservaService
{
    public interface ICriarReservaCommand
    {
         int ClienteId { get; }
         int QuartoId { get; }
         int ReservaId { get; }
         DateTime DataCheckIn { get; }
         DateTime DataCheckOut { get; }
         int NumeroHospedes { get; }
    }
}
