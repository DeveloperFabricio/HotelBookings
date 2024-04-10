using HotelBookings.Core.Entities;
using HotelBookings.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HotelBookings.Infrastructure.Persistence.Repositories
{
    public class HotelRepository : IHotelRepository
    {
        private readonly HotelDbContext _context;

        public HotelRepository(HotelDbContext context)
        {
            _context = context;
        }

        public async Task Adicionar(Hotel hotel)
        {
            await _context.Hoteis.AddAsync(hotel);
            await _context.SaveChangesAsync();
        }

        public async Task Atualizar(Hotel hotel)
        {
            _context.Entry(hotel).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<Hotel> ObterPorId(int id)
        {
            return await _context.Hoteis.FirstOrDefaultAsync(h => h.ID == id);
        }

        public async Task<IEnumerable<Hotel>> ObterTodos()
        {
            return await _context.Hoteis.ToListAsync();
        }

        public async Task Remover(Hotel hotel)
        {
            _context.Hoteis.Remove(hotel);
            await _context.SaveChangesAsync();
        }

        public async Task SavesChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
