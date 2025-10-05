using Application.Interfaces;
using Domain.Interfaces;
using Domain.Models;
using FluentValidation;
using FluentValidation.Results;

namespace Application.Services
{
    public class CustomFieldService : ICustomFieldService
    {
        private readonly IValidator<CustomField> validator;
        private readonly ICustomFieldRepository customFieldRepository;

        public CustomFieldService(IValidator<CustomField> validator, ICustomFieldRepository customFieldRepository)
        {
            this.validator = validator;
            this.customFieldRepository = customFieldRepository;
        }

        public void Create(CustomField customField)
        {
            ValidationResult validationResult = validator.Validate(customField);

            if (validationResult.IsValid)
            {
                customFieldRepository.Create(customField);
            }
            else
            {
                throw new ValidationException(validationResult.Errors);
            }
        }

        public void Update(CustomField customField)
        {
            ValidationResult validationResult = validator.Validate(customField);

            if (validationResult.IsValid)
            {
                customFieldRepository.Update(customField);
            }
            else
            {
                throw new ValidationException(validationResult.Errors);
            }
        }
    }
}