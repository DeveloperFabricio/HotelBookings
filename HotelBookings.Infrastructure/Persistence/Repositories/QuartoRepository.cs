using HotelBookings.Core.Entities;
using HotelBookings.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HotelBookings.Infrastructure.Persistence.Repositories
{
    public class QuartoRepository : IQuartoRepository
    {
        private readonly HotelDbContext _context;

        public QuartoRepository(HotelDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Quarto>> ObterTodos()
        {
            return await _context.Quartos.ToListAsync();
        }

        public async Task<Quarto> ObterPorId(int id)
        {
            return await _context.Quartos.FirstOrDefaultAsync(q => q.ID == id);
        }

        public async Task Adicionar(Quarto quarto)
        {
            await _context.Quartos.AddAsync(quarto);
            await _context.SaveChangesAsync();
        }

        public async Task Atualizar(Quarto quarto)
        {
            _context.Entry(quarto).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Remover(Quarto quarto)
        {
            _context.Quartos.Remove(quarto);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Quarto>> ObterQuartosDisponiveis()
        {
            return await _context.Quartos.Where(q => q.Disponivel).ToListAsync();
        }
    }

}