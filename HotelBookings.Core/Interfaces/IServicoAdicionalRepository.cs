using HotelBookings.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookings.Core.Interfaces
{
    public interface IServicoAdicionalRepository
    {
        Task<IEnumerable<ServicoAdicional>> ObterTodos();
        Task<ServicoAdicional> ObterPorId(int id);
        Task Adicionar(ServicoAdicional servicoAdicional);
        Task Atualizar(ServicoAdicional servicoAdicional);
        Task Remover(ServicoAdicional servicoAdicional);
    }
}
