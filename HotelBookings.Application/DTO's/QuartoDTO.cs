using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookings.Application.DTO_s
{
    public class QuartoDTO
    {
        public int Id { get; set; }
        public string NumeroQuarto { get; set; }
        public string TipoQuarto { get; set; }
        public decimal PrecoPorNoite { get; set; }
        public string Descricao { get; set; }
    }
}
