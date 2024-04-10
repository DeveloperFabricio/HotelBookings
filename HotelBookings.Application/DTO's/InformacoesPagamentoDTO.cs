using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookings.Application.DTO_s
{
    public class InformacoesPagamentoDTO
    {
        public int Id { get; set; }
        public int ReservaId { get; set; }
        public string MetodoPagamento { get; set; }
        public decimal ValorPago { get; set; }
        public string StatusPagamento { get; set; }
        public DateTime DataHoraPagamento { get; set; }
    }
}
