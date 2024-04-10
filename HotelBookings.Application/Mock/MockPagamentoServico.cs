using HotelBookings.Application.DTO_s;
using HotelBookings.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookings.Application.Mock
{
    public class MockPagamentoServico : IPagamentoServico
    {
        public void ProcessandoPagamento(PagamentoClienteDTO pagamentoCliente)
        {
            throw new NotImplementedException();
        }
    }
}
