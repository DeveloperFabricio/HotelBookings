using FluentValidation;
using HotelBookings.Application.Models.InputModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookings.Application.Validators
{
    public class ReservaInputModelValidator : AbstractValidator<ReservaInputModel>
    {
        public ReservaInputModelValidator()
        {
            RuleFor(model => model.DataCheckIn).NotEmpty().WithMessage("A data de check-in é obrigatória.");
            RuleFor(model => model.DataCheckOut).NotEmpty().WithMessage("A data de check-out é obrigatória.")
                                                 .GreaterThan(model => model.DataCheckIn).WithMessage("A data de check-out deve ser posterior à data de check-in.");
            RuleFor(model => model.NumeroHospedes).GreaterThan(0).WithMessage("O número de hóspedes deve ser maior que zero.");
        }
    }
    
    
}
