using HotelBookings.Core.Entities;
using HotelBookings.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookings.Infrastructure.Persistence.Repositories
{
    public class AvaliacaoDoClienteRepository : IAvaliacaoDoClienteRepository
    {
        private readonly HotelDbContext _context;

        public AvaliacaoDoClienteRepository(HotelDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AvaliacaoDoCliente>> ObterTodos()
        {
            return await _context.AvaliacoesDosClientes.ToListAsync();
        }

        public async Task<AvaliacaoDoCliente> ObterPorId(int id)
        {
            return await _context.AvaliacoesDosClientes.FirstOrDefaultAsync(a => a.ID == id);
        }

        public async Task Adicionar(AvaliacaoDoCliente avaliacaoDoCliente)
        {
            await _context.AvaliacoesDosClientes.AddAsync(avaliacaoDoCliente);
            await _context.SaveChangesAsync();
        }

        public async Task Atualizar(AvaliacaoDoCliente avaliacaoDoCliente)
        {
            _context.Entry(avaliacaoDoCliente).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Remover(AvaliacaoDoCliente avaliacaoDoCliente)
        {
            _context.AvaliacoesDosClientes.Remove(avaliacaoDoCliente);
            await _context.SaveChangesAsync();
        }
    
    }
}
