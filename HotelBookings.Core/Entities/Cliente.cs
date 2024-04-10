using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookings.Core.Entities
{
    public class Cliente
    {
        public int ID { get; private set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public ICollection<Reserva> Reservas { get; private set; }

        public Cliente()
        {
            Reservas = new List<Reserva>();
        }
    }
}
