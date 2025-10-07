using Application.Interfaces;
using Domain.Interfaces;
using Domain.Models;
using FluentValidation;
using FluentValidation.Results;

namespace Application.Services
{
    public class SupplierService : ISupplierService
    {
        private readonly IValidator<Supplier> validator;
        private readonly ISupplierRepository supplierRepository;
        private readonly ICountryRepository countryRepository;
        private readonly ICountryService countryService;

        public SupplierService(
            IValidator<Supplier> validator, 
            ISupplierRepository supplierRepository,
            ICountryRepository countryRepository,
            ICountryService countryService)
        {
            this.validator = validator;
            this.supplierRepository = supplierRepository;
            this.countryRepository = countryRepository;
            this.countryService = countryService;
        }

        public void Create(Supplier supplier)
        {
            ValidationResult validationResult = validator.Validate(supplier);

            if (validationResult.IsValid)
            {
                List<Country> countries = new();

                supplier.Services.ForEach(service =>
                {
                    countries.AddRange(service.Countries);
                });

                countries = countryService.CreateList(countries);

                supplierRepository.Create(supplier);
            }
            else
            {
                throw new ValidationException(validationResult.Errors);
            }
        }

        public void Update(Supplier supplier)
        {
            ValidationResult validationResult = validator.Validate(supplier);

            if (validationResult.IsValid)
            {
                List<Country> countries = new();

                supplier.Services.ForEach(service =>
                {
                    countries.AddRange(service.Countries);
                });

                countries = countryService.CreateList(countries);

                supplierRepository.Update(supplier);
            }
            else
            {
                throw new ValidationException(validationResult.Errors);
            }
        }
    }
}