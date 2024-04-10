using HotelBookings.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookings.Core.Interfaces
{
    public interface IInformacoesDePagamentoRepository
    {
        Task<IEnumerable<InformacoesDePagamento>> ObterTodos();
        Task<InformacoesDePagamento> ObterPorId(int id);
        Task Adicionar(InformacoesDePagamento informacoesDePagamento);
        Task Atualizar(InformacoesDePagamento informacoesDePagamento);
        Task Remover(InformacoesDePagamento informacoesDePagamento);
    }
}

