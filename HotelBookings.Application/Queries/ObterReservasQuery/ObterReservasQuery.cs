using HotelBookings.Application.DTO_s;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookings.Application.Queries.ObterReservasQuery
{
    public class ObterReservasQuery : IRequest<IEnumerable<ReservaDTO>>
    {
    }
}
