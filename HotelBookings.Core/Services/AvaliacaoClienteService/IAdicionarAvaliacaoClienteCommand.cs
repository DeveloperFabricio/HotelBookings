using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookings.Core.Services.AvaliacaoClienteService
{
    public interface IAdicionarAvaliacaoClienteCommand
    {
         int IDDoCliente { get; }
         int IDDoHotel { get; }
         int Classificacao { get; }
         string Comentario { get; }
         DateTime DataDaAvaliacao { get; }
    }
}
