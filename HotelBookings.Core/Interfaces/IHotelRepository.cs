using HotelBookings.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookings.Core.Interfaces
{
    public interface IHotelRepository
    {
        Task<IEnumerable<Hotel>> ObterTodos();
        Task<Hotel> ObterPorId(int id);
        Task Adicionar(Hotel hotel);
        Task Atualizar(Hotel hotel);
        Task Remover(Hotel hotel);
        Task SavesChangesAsync();
    }
}
