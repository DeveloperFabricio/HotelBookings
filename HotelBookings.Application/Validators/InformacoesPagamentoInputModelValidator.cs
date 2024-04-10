using FluentValidation;
using HotelBookings.Application.Models.InputModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookings.Application.Validators
{
    public class InformacoesPagamentoInputModelValidator : AbstractValidator<InformacoesPagamentoInputModel>
    {
        public InformacoesPagamentoInputModelValidator()
        {
            RuleFor(i => i.ReservaId).NotEmpty();
            RuleFor(i => i.MetodoPagamento).NotEmpty();
            RuleFor(i => i.ValorPago).NotEmpty().GreaterThan(0);
        }    
    }
}
