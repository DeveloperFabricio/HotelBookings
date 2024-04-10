using FluentValidation;
using HotelBookings.Application.Models.InputModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookings.Application.Validators
{
    public class AvaliacaoClienteInputModelValidator : AbstractValidator<AvaliacaoClienteInputModel>
    {
        public AvaliacaoClienteInputModelValidator()
        {
            RuleFor(a => a.ClienteId).NotEmpty();
            RuleFor(a => a.HotelId).NotEmpty();
            RuleFor(a => a.Classificacao).NotEmpty().InclusiveBetween(1, 5);
            RuleFor(a => a.Comentario).NotEmpty();
            RuleFor(a => a.DataAvaliacao).NotEmpty();
        }
    

    }
}
