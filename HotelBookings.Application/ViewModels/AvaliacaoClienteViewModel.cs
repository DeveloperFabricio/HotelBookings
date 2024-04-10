using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookings.Application.ViewModels
{
    public class AvaliacaoClienteViewModel
    {
        public int Id { get; set; }
        public int IdCliente { get; set; }
        public int IdHotel { get; set; }
        public int Classificacao { get; set; }
        public string Comentario { get; set; }
        public DateTime DataAvaliacao { get; set; }
    }
}
