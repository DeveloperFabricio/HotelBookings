using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookings.Core.Entities
{
    public class EventoDeDominio
    {
        public string TipoDeEvento { get; set; }
        public string DadosRelevantes { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
