using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookings.Application.Models.InputModels
{
    public class InformacoesPagamentoInputModel
    {
        public int ReservaId { get; set; }
        public string MetodoPagamento { get; set; }
        public decimal ValorPago { get; set; }
    }
}
