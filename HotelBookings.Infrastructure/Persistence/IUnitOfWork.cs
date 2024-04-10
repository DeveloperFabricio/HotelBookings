using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookings.Infrastructure.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        Task<bool> Sucesso();
        Task<string> MensagemErro();
        Task<int> SaveChangesAsync();
        Task<int> CommitAsync();
        Task<int> DeleteAsync<TEntity>(TEntity entity) where TEntity : class;
    }
}
