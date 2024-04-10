using FluentValidation;
using HotelBookings.Application.Models.InputModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookings.Application.Validators
{
    public class ClienteInputModelValidator : AbstractValidator<ClienteInputModel>
    {
        public ClienteInputModelValidator()
        {
            RuleFor(c => c.Nome).NotEmpty();
            RuleFor(c => c.Email).NotEmpty().EmailAddress();
            RuleFor(c => c.Telefone).NotEmpty();
        }
    
    }
}
