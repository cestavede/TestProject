using System;
using System.Collections.Generic;

namespace BusinessRegistryApi
{
    public interface ITempDb
    {
        IEnumerable<CompanyItem> GetAll();

        CompanyItem GetById(int id);

        CompanyItem GetByName(string name);

        IEnumerable<CompanyItem> SearchByName(string name);

        CompanyItem InsertCompany(CompanyItem company);

        void DeleteCompany(int id);

        bool Init();
    }
}
