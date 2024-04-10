using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookings.Application.DTO_s
{
    public class ReservaDTO
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public int QuartoId { get; set; }
        public DateTime DataCheckIn { get; set; }
        public DateTime DataCheckOut { get; set; }
        public int NumeroHospedes { get; set; }
        public string StatusReserva { get; set; }
    }
}
