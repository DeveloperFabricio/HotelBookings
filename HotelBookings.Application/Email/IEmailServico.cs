using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookings.Application.Email
{
    public interface IEmailServico
    {
        Task<bool> EnviarEmail(string email, string assunto, string mensagem);
    }
}
