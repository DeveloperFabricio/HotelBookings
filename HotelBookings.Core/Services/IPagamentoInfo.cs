using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookings.Core.Services
{
    public interface IPagamentoInfo
    {
        int ClienteId { get; }
        string CartaoCredito { get; }
        string Cvv { get; }
        string Expira { get; }
        string NomeCompleto { get; }
        decimal Quantia { get; }
    }
}
