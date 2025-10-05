using Domain.Models;
using FluentValidation;

namespace Application.Validators
{
    public class SupplierValidator : AbstractValidator<Supplier>
    {
        public SupplierValidator()
        {
            RuleFor(s => s.Nit)
                .NotEmpty().WithMessage("El NIT es obligatorio");

            RuleFor(s => s.Name)
                .NotEmpty().WithMessage("El nombre es obligatorio");

            RuleFor(s => s.Email)
                .EmailAddress().WithMessage("El correo no es válido");
        }
    }
}