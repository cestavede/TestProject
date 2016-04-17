using System;

namespace BusinessRegistryApi
{
    public class FakeDataGenerator : IDisposable
    {
        ICompanyRepository _companies;
        public FakeDataGenerator(ICompanyRepository repo)
        {
            _companies = repo;
        }

        public void Dispose()
        {
            _companies = null;
        }

        public void GeenerateSomeData()
        {
            var c1 = new CompanyItem() { CompanyId = 1, Address = "Praha", CompanyName = "Startup", ICO = "123001" };
            var c2 = new CompanyItem() { CompanyId = 2, Address = "Boleslav", CompanyName = "Auta cz", ICO = "123002" };
            var c3 = new CompanyItem() { CompanyId = 3, Address = "Ostrava", CompanyName = "Doly CR a.s.", ICO = "123003" };

            var c4 = new CompanyItem() { CompanyId = 4, Address = "Praha", CompanyName = "Startup s.r.o.", ICO = "123004" };
            var c5 = new CompanyItem() { CompanyId = 5, Address = "Praha", CompanyName = "Startup a.s.", ICO = "123005" };

            var c6 = new CompanyItem() { CompanyId = 6, Address = "Plzen", CompanyName = "1", ICO = "123006" };

            _companies.Add(c1);
            _companies.Add(c2);
            _companies.Add(c3);
            _companies.Add(c4);
            _companies.Add(c5);
            _companies.Add(c6);
        }
    }
}
