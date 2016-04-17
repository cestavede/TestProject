using System;
using System.Collections.Generic;

namespace BusinessRegistryApi
{
    public class CompanyRepository : ICompanyRepository
    {
        private ITempDb _inMemoryData;
        public CompanyRepository(ITempDb inMemoryData)
        {
            _inMemoryData = inMemoryData;

            // If Init not beeing called UnitTest will fail
            if (!_inMemoryData.Init())
                throw new InvalidOperationException("Database initialization failed");

            // Init should be called only once
            //_inMemoryData.Init();

            // Need better approach out of constructor
            using (var dataGen = new FakeDataGenerator(this))
            {
                dataGen.GeenerateSomeData();
            }
        }

        public CompanyItem Add(CompanyItem item)
        {
            return _inMemoryData.InsertCompany(item);
        }

        public CompanyItem Find(int id)
        {
            return _inMemoryData.GetById(id);
        }

        public CompanyItem Find(string name)
        {
            return _inMemoryData.GetByName(name);
        }

        public IEnumerable<CompanyItem> Search(string name)
        {
            return _inMemoryData.SearchByName(name);
        }

        public IEnumerable<CompanyItem> GetAll()
        {
            return _inMemoryData.GetAll();
        }

        public void Remove(int id)
        {
            _inMemoryData.DeleteCompany(id);
        }

        public void Update(CompanyItem item)
        {
            throw new NotImplementedException();
        }
    }
}