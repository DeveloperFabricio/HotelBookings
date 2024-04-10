using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookings.Application.ViewModels
{
    public class InformacoesPagamentoViewModel
    {
        public int Id { get; set; }
        public int IdReserva { get; set; }
        public string MetodoPagamento { get; set; }
        public decimal ValorPago { get; set; }
        public string StatusPagamento { get; set; }
        public DateTime DataHoraPagamento { get; set; }
    }
}
