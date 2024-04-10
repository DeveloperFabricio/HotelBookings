using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookings.Core.Entities
{
    public class Reserva
    {
        public int ID { get; set; }
        public int IDDoCliente { get; set; }
        public int IDDoQuarto { get; set; }
        public DateTime DataDeCheckIn { get; set; }
        public DateTime DataDeCheckOut { get; set; }
        public int NumeroDeHospedes { get; set; }
        public string StatusDaReserva { get; set; }
        public Cliente Cliente { get; set; }
        public int ClienteID { get; set; }
        public virtual Quarto Quarto { get; set; }
    }
}
