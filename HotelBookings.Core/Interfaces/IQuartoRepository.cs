using HotelBookings.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookings.Core.Interfaces
{
    public interface IQuartoRepository
    {
        Task<IEnumerable<Quarto>> ObterTodos();
        Task<Quarto> ObterPorId(int id);
        Task Adicionar(Quarto quarto);
        Task Atualizar(Quarto quarto);
        Task Remover(Quarto quarto);
        Task<IEnumerable<Quarto>> ObterQuartosDisponiveis();
    }
}
