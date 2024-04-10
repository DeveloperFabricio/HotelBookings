using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookings.Core.Entities
{
    public class AvaliacaoDoCliente
    {
        public int ID { get; private set; }
        public int IDDoCliente { get; set; }
        public int IDDoHotel { get; set; }
        public int Classificacao { get; set; }
        public string Comentario { get; set; }
        public DateTime DataDaAvaliacao { get; set; }
    }
}
