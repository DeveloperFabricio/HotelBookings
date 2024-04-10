using HotelBookings.Application.DTO_s;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookings.Application.Queries.ObterClienteQuery
{
    public class ObterClienteQuery : IRequest<ClienteDTO>
    {
        public int ClienteId { get; set; }
    }
}
