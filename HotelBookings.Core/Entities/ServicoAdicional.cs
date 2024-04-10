using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookings.Core.Entities
{
    public class ServicoAdicional
    {
        public int ID { get; private set; }
        public string NomeDoServico { get; set; }
        public string Descricao { get; set; }
        public decimal PrecoAdicional { get; set; }
    }
}
