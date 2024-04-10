using HotelBookings.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookings.Core.Entities
{
    public class Hotel
    {
        public int ID { get; set; }
        public string? Nome { get; set; }
        public string? Endereco { get; set; }
        public string? Descricao { get; set; }
        public decimal CustoTotal { get; set; }
        public DateTime Criacao { get; set; }
        public DateTime? Comecou { get; set; }
        public DateTime? Finalizou { get; set; }
        public PagamentoStatusEnum Status { get; set; }
        public ICollection<Quarto> Quartos { get; set; }


        public void Cancelado()
        {
            if (Status == PagamentoStatusEnum.EmAndamento || Status == PagamentoStatusEnum.Criado)
            {
                Status = PagamentoStatusEnum.Cancelado;
            }
        }

        public void Inicio()
        {
            if (Status == PagamentoStatusEnum.Criado)
            {
                Status = PagamentoStatusEnum.EmAndamento;
                Comecou = DateTime.Now;
            }
        }

        public void Finalizado()
        {
            if (Status == PagamentoStatusEnum.PagamentoPendente)
            {
                Status = PagamentoStatusEnum.Concluído;
                Finalizou = DateTime.Now;
            }
        }

        public void DefinirPagamentoPendente()
        {
            Status = PagamentoStatusEnum.PagamentoPendente;
            Finalizou = null;
        }

        public void Atualizar(string nome, string descricao, decimal custoTotal)
        {
            Nome = nome;
            Descricao = descricao;
            CustoTotal = custoTotal;
        }
    }
}
