using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookings.Infrastructure.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly HotelDbContext _context;
        private readonly ILogger<UnitOfWork> _logger;

        public UnitOfWork(HotelDbContext context, ILogger<UnitOfWork> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task<int> CommitAsync()
        {
            return await SaveChangesAsync();
        }

        public async Task<int> DeleteAsync<TEntity>(TEntity entity) where TEntity : class
        {
            _context.Set<TEntity>().Remove(entity);
            return await SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<bool> Sucesso()
        {
            try
            {
                await _context.SaveChangesAsync();
                return true; 
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao salvar alterações no banco de dados.");
                return false; 
            }
        }

        public async Task<string> MensagemErro()
        {
            try
            {
                await _context.SaveChangesAsync();
                return null; 
            }
            catch (Exception ex)
            {
                return ex.Message; 
            }
        }
    }
}
