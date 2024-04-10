using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookings.Application.Models.InputModels
{
    public class ReservaInputModel
    {
        public DateTime DataCheckIn { get; set; }
        public DateTime DataCheckOut { get; set; }
        public int NumeroHospedes { get; set; }
    }
}
