using HotelBookings.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookings.Core.Interfaces
{
    public interface IClienteRepository
    {
        Task<IEnumerable<Cliente>> ObterTodos();
        Task<Cliente> ObterPorId(int id);
        Task Adicionar(Cliente cliente);
        Task Atualizar(Cliente cliente);
        Task Remover(Cliente cliente);
        Task SaveChangesAsync();
    }
}
