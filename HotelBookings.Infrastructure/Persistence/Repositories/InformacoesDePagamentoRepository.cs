using HotelBookings.Core.Entities;
using HotelBookings.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Text;
using RabbitMQ.Client;

namespace HotelBookings.Infrastructure.Persistence.Repositories
{
    public class InformacoesDePagamentoRepository : IInformacoesDePagamentoRepository
    {
        private readonly HotelDbContext _context;

        public InformacoesDePagamentoRepository(HotelDbContext context)
        {
            _context = context;

        }

        public async Task<IEnumerable<InformacoesDePagamento>> ObterTodos()
        {
            return await _context.InformacoesDePagamento.ToListAsync();
        }

        public async Task<InformacoesDePagamento> ObterPorId(int id)
        {
            return await _context.InformacoesDePagamento.FirstOrDefaultAsync(i => i.ID == id);
        }

        public async Task Adicionar(InformacoesDePagamento informacoesDePagamento)
        {
            await _context.InformacoesDePagamento.AddAsync(informacoesDePagamento);
            await _context.SaveChangesAsync();
        }

        public async Task Atualizar(InformacoesDePagamento informacoesDePagamento)
        {
            _context.Entry(informacoesDePagamento).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Remover(InformacoesDePagamento informacoesDePagamento)
        {
            _context.InformacoesDePagamento.Remove(informacoesDePagamento);
            await _context.SaveChangesAsync();
        }

    }   
}
