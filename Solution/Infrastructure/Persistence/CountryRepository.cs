using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Providers;
using Microsoft.EntityFrameworkCore;
using RestSharp;

namespace Infrastructure.Persistence
{
    public class CountryRepository : ICountryRepository
    {
        private readonly string api = "https://www.apicountries.com/";
        private readonly AppDbContext dbContext;

        public CountryRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<Country> GetList()
        {
            return RestProvider.GetList<Country>($"{api}countries", Method.Get);
        }

        public Country GetByCode(string code)
        {
            return RestProvider.Get<Country>($"{api}alpha/{code}", Method.Get);
        }

        public List<Country> CreateList(List<Country> countries)
        {
            dbContext.COUNTRY.AddRange(countries);
            dbContext.SaveChanges();
            return countries;
        }

        public List<Country> GetCreatedList()
        {
            return dbContext.COUNTRY.ToList();
        }
    }
}