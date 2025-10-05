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

        public SupplierService(
            IValidator<Supplier> validator, 
            ISupplierRepository supplierRepository,
            ICountryRepository countryRepository)
        {
            this.validator = validator;
            this.supplierRepository = supplierRepository;
            this.countryRepository = countryRepository;
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

                countries = countryRepository.CreateList(countries);

                supplier.Services.ForEach(service =>
                {
                    service.Countries.ForEach(country => country = countries.First(c => c.Code == country.Code));
                });

                supplierRepository.Create(supplier);
            }
            else
            {
                throw new ValidationException(validationResult.Errors);
            }
        }
    }
}