using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookings.Application.DTO_s
{
    public class AvaliacaoClienteDTO
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public int HotelId { get; set; }
        public int Classificacao { get; set; }
        public string Comentario { get; set; }
        public DateTime DataAvaliacao { get; set; }
    }
}
