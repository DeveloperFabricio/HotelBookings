using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookings.Core.Services.PagamentoClienteService
{
    public interface IPagamentoClienteCommand
    {
         int Id { get; }
         string CartaoCredito { get; }
         string Cvv { get; }
         string Expira { get; }
         string NomeCompleto { get; }
    }
}
