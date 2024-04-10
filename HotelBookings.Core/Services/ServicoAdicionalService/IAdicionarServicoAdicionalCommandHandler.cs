using MediatR;

namespace HotelBookings.Core.Services.ServicoAdicionalService
{
    public interface IAdicionarServicoAdicionalCommandHandler
    {
        Task<Unit> Handle(IAdicionarServicoAdicionalCommand request, CancellationToken cancellationToken);
    }
}
