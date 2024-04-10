using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookings.Core.Entities
{
    public class InformacoesDePagamento
    {
        public int ID { get; private set; }
        public int IDDaReserva { get; set; }
        public string MetodoDePagamento { get; set; }
        public decimal ValorPago { get; set; }
        public string StatusDoPagamento { get; set; }
        public DateTime DataEHoraDoPagamento { get; set; }
    }
}
