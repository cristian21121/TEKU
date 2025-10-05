using Domain.Models;
using Infrastructure;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Test
{
    [TestClass]
    public class CountryRepositoryTest
    {
        private readonly AppDbContext dbContext;

        public CountryRepositoryTest()
        {
            this.dbContext = new AppDbContext(new DbContextOptionsBuilder<AppDbContext>()
            .UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=API;Trusted_Connection=True;TrustServerCertificate=True;")
            .Options);
        }

        [TestMethod]
        public void Test()
        {
            CountryRepository countryRepository = new(dbContext);
            List<Country> countries = countryRepository.GetList();
            countryRepository.CreateList(countries);
            Assert.IsTrue(countries.Any());
        }
    }
}