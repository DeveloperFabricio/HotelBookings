using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookings.Core.Services.PagamentoClienteService
{
    public interface IPagamentoClienteCommandHandler 
    {
        Task<bool> Handle(IPagamentoClienteCommand request, CancellationToken cancellationToken);
    }
}
