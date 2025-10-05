using Domain.Models;
using FluentValidation;

namespace Application.Validators
{
    public class ServiceValidator : AbstractValidator<Service>
    {
        public ServiceValidator()
        {
            RuleFor(s => s.SupplierId)
                .NotEmpty().WithMessage("El Id del proveedor es obligatorio");

            RuleFor(s => s.Name)
                .NotEmpty().WithMessage("El nombre es obligatorio");

            RuleFor(s => s.HourValue)
                .NotEmpty().WithMessage("El valor por hora es obligatorio");
        }
    }
}