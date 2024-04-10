using HotelBookings.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookings.Core.Interfaces
{
    public interface IReservaRepository
    {
        Task<IEnumerable<Reserva>> ObterTodos();
        Task<Reserva> ObterPorId(int id);
        Task Adicionar(Reserva reserva);
        Task Atualizar(Reserva reserva);
        Task Remover(Reserva reserva);
    }
}
