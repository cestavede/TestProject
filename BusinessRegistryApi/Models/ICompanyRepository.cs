using System;
using System.Collections.Generic;

namespace BusinessRegistryApi
{
    public interface ICompanyRepository
    {
        CompanyItem Add(CompanyItem item);
        IEnumerable<CompanyItem> GetAll();
        CompanyItem Find(int id);

        CompanyItem Find(string name);

        IEnumerable<CompanyItem> Search(string name);

        void Remove(int id);
        void Update(CompanyItem item);
    }
}