using Domain.Models;
using FluentValidation;

namespace Application.Validators
{
    public class CustomFieldValidator : AbstractValidator<CustomField>
    {
        public CustomFieldValidator()
        {
            RuleFor(c => c.SupplierId)
                .NotEmpty().WithMessage("El Id del proveedor es obligatorio");

            RuleFor(c => c.Value)
                .NotEmpty().WithMessage("El valor es obligatorio");

            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("El nombre es obligatorio");
        }
    }
}