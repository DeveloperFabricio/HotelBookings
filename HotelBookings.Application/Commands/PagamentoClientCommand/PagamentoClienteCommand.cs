using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookings.Application.Commands.PagamentoClientCommand
{
    public class PagamentoClienteCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public string CartaoCredito { get; set; }
        public string Cvv { get; set; }
        public string Expira { get; set; }
        public string NomeCompleto { get; set; }
    }
}
