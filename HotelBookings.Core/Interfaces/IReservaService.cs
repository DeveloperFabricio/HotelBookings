using HotelBookings.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookings.Core.Interfaces
{
    public interface IReservaService
    {
        Task EnviarEmailConfirmacaoReserva(Cliente cliente, Reserva reserva);
    }
}
