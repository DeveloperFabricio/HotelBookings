using HotelBookings.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookings.Core.Interfaces
{
    public interface IAvaliacaoDoClienteRepository
    {
        Task<IEnumerable<AvaliacaoDoCliente>> ObterTodos();
        Task<AvaliacaoDoCliente> ObterPorId(int id);
        Task Adicionar(AvaliacaoDoCliente avaliacaoDoCliente);
        Task Atualizar(AvaliacaoDoCliente avaliacaoDoCliente);
        Task Remover(AvaliacaoDoCliente avaliacaoDoCliente);
    }
}
