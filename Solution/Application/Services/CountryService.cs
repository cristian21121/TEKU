using Application.Interfaces;
using Domain.Interfaces;
using Domain.Models;

namespace Application.Services
{
    public class CountryService : ICountryService
    {
        private readonly ICountryRepository countryRepository;

        public CountryService(ICountryRepository countryRepository)
        {
            this.countryRepository = countryRepository;
        }

        public List<Country> CreateList(List<Country> countries)
        {
            List<Country> allCountries = countryRepository.GetList();
            List<Country> createdCountries = countryRepository.GetCreatedList();

            foreach (Country country in countries)
            {
                Country? registeredCountry = createdCountries.FirstOrDefault(c => c.Code == country.Code);

                if (registeredCountry != null)
                {
                    country.Id = registeredCountry.Id;
                }
                else
                {
                    country.Name = allCountries.First(c => c.Code == country.Code).Name;
                }
            }

            countryRepository.CreateList(countries.DistinctBy(c => c.Code).Where(c => c.Id == 0).ToList());
            
            return countries;
        }
    }
}
