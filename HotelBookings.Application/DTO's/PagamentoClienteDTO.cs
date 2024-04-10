using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookings.Application.DTO_s
{
    public class PagamentoClienteDTO
    {
        public PagamentoClienteDTO(int clienteID, string cartaoCredito, string cvv, string expira, string nomeCompleto, decimal quantia)
        {
            ClienteID = clienteID;
            CartaoCredito = cartaoCredito;
            Cvv = cvv;
            Expira = expira;
            NomeCompleto = nomeCompleto;
            Quantia = quantia;
        }

        public int ClienteID { get; private set; }
        public string CartaoCredito { get; private set; }
        public string Cvv { get; private set; }
        public string Expira { get; private set; }
        public string NomeCompleto { get; private set; }
        public decimal Quantia { get; private set; }
    }
}
