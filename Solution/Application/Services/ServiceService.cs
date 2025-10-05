using Application.Interfaces;
using Domain.Interfaces;
using Domain.Models;
using FluentValidation;
using FluentValidation.Results;

namespace Application.Services
{
    public class ServiceService : IServiceService
    {
        private readonly IValidator<Service> validator;
        private readonly IServiceRepository serviceRepository;

        public ServiceService(IValidator<Service> validator, IServiceRepository serviceRepository)
        {
            this.validator = validator;
            this.serviceRepository = serviceRepository;
        }

        public void Create(Service service)
        {
            ValidationResult validationResult = validator.Validate(service);

            if (validationResult.IsValid)
            {
                serviceRepository.Create(service);
            }
            else
            {
                throw new ValidationException(validationResult.Errors);
            }
        }

        public void Update(Service service)
        {
            ValidationResult validationResult = validator.Validate(service);

            if (validationResult.IsValid)
            {
                serviceRepository.Update(service);
            }
            else
            {
                throw new ValidationException(validationResult.Errors);
            }
        }
    }
}