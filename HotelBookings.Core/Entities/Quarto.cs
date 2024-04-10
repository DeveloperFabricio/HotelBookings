using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookings.Core.Entities
{
    public class Quarto
    {
        public int ID { get; set; }
        public string NumeroDoQuarto { get; set; }
        public string TipoDeQuarto { get; set; }
        public string Descricao { get; set; }
        public decimal PrecoPorNoite { get; set; }
        public bool Disponivel { get; set; }
        public ICollection<Reserva> Reservas { get; set; }

        public Quarto()
        {
            Reservas = new List<Reserva>();
        }
    }
}
