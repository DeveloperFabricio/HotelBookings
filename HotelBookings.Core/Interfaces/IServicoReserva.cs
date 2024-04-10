using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookings.Core.Interfaces
{
    public interface IServicoReserva
    {
        Task ProcessarConfirmacaoReserva(int idReserva);
    }
}
