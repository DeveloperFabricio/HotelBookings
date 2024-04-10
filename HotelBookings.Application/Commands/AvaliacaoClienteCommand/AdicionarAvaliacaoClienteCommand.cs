using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookings.Application.Commands.AvaliacaoClienteCommand
{
    public class AdicionarAvaliacaoClienteCommand : IRequest<Unit>
    {
        public int IDDoCliente { get; set; }
        public int IDDoHotel { get; set; }
        public int Classificacao { get; set; }
        public string Comentario { get; set; }
        public DateTime DataDaAvaliacao { get; set; }
    }
    
    
}
