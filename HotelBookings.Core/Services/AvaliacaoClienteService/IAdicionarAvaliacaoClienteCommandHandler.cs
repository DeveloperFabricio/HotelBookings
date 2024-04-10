using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookings.Core.Services.AvaliacaoClienteService
{
    public interface IAdicionarAvaliacaoClienteCommandHandler 
    {
        Task<Unit> Handle(IAdicionarAvaliacaoClienteCommand request, CancellationToken cancellationToken);
    }
}
