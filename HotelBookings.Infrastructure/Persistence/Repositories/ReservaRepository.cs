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
    public class ReservaRepository : IReservaRepository
    {
        private readonly HotelDbContext _context;

        public ReservaRepository(HotelDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Reserva>> ObterTodos()
        {
            return await _context.Reservas.ToListAsync();
        }

        public async Task<Reserva> ObterPorId(int id)
        {
            return await _context.Reservas.FirstOrDefaultAsync(r => r.ID == id);
        }

        public async Task Adicionar(Reserva reserva)
        {
            await _context.Reservas.AddAsync(reserva);
            await _context.SaveChangesAsync();
        }

        public async Task Atualizar(Reserva reserva)
        {
            _context.Entry(reserva).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Remover(Reserva reserva)
        {
            _context.Reservas.Remove(reserva);
            await _context.SaveChangesAsync();
        }
    }
    
    
}
