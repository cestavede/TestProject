using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace BusinessRegistryApi
{
    /// <summary>
    /// This is naive db implementation (normally I would let Repository use proper db)
    /// </summary>
    public class InMemoryData : ITempDb
    {
        private Dictionary<int,CompanyItem> _companies;

        public InMemoryData()
        {
            // Not ideal type for hosting Dictionary like data, but good example of possible problems
            // _companies = new List<CompanyItem>();

            _companies = new Dictionary<int,CompanyItem>();
        }

        public bool Init()
        {
            // Does nothing for now, might change later.
            // Need to be called by consumer after instantiation.

            Debug.WriteLine( "Initializing InMemory data storage" );
            return true;
        }

        

        public IEnumerable<CompanyItem> GetAll()
        {
            return _companies.Values;
        }

        public CompanyItem GetById(int id)
        {
            if (!_companies.ContainsKey(id))
                return null;

            return _companies[id];
        }

        public CompanyItem GetByName(string name)
        {
            return _companies.Values.FirstOrDefault(c => c.CompanyName.Equals(name, StringComparison.CurrentCultureIgnoreCase));
        }

        public IEnumerable<CompanyItem> SearchByName(string name)
        {
            return _companies.Values.Where(c => c.CompanyName.StartsWith(name,StringComparison.CurrentCultureIgnoreCase) );
        }

        private int GetNextAvailableId()
        {
            // Proper db will have proper identity@@ implementation

            // Need at least some thread safetiness
            lock (this)
            {
                if (_companies.Any())
                    return _companies.Keys.Max();
                else
                    return 1;
            }
        }

        public CompanyItem InsertCompany(CompanyItem company)
        {
            if (company.CompanyId <= 0)
                company.CompanyId = GetNextAvailableId();

            if (GetById(company.CompanyId) != null)
                throw new InvalidOperationException("Foreign Key Constraint violation");

            _companies.Add(company.CompanyId, company);

            return company;
        }

        public void DeleteCompany(int id)
        {
            _companies.Remove(id);
        }

        public void UpdateCompany()
        {
            // TODO: Id should not be possible to Update

            throw new NotImplementedException();
        }
    }
}
