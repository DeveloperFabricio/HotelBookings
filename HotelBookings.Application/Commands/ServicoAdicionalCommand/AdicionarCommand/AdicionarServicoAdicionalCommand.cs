using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookings.Application.Commands.ServicoAdicionalCommand.AdicionarCommand
{
    public class AdicionarServicoAdicionalCommand : IRequest<Unit>
    {
        public int ReservaId { get; set; }
        public string NomeDoServico { get; set; }
        public string Descricao { get; set; }
        public decimal PrecoAdicional { get; set; }
    }
    
    
}
