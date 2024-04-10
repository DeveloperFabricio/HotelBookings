using HotelBookings.Core.Entities;
using HotelBookings.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HotelBookings.Infrastructure.Persistence.Repositories
{
    public class ServicoAdicionalRepository : IServicoAdicionalRepository
    {
        private readonly HotelDbContext _context;

        public ServicoAdicionalRepository(HotelDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ServicoAdicional>> ObterTodos()
        {
            return await _context.ServicosAdicionais.ToListAsync();
        }

        public async Task<ServicoAdicional> ObterPorId(int id)
        {
            return await _context.ServicosAdicionais.FirstOrDefaultAsync(s => s.ID == id);
        }

        public async Task Adicionar(ServicoAdicional servicoAdicional)
        {
            await _context.ServicosAdicionais.AddAsync(servicoAdicional);
            await _context.SaveChangesAsync();
        }

        public async Task Atualizar(ServicoAdicional servicoAdicional)
        {
            _context.Entry(servicoAdicional).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Remover(ServicoAdicional servicoAdicional)
        {
            _context.ServicosAdicionais.Remove(servicoAdicional);
            await _context.SaveChangesAsync();
        }
    
    }
}
