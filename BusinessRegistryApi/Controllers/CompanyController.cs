using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessRegistryApi
{
    [Route("api/[controller]")]
    public class CompanyController :  Controller
    {
        private ICompanyRepository _repo;
        public CompanyController(ICompanyRepository repository)
        {
            _repo = repository;
        }

        [FromServices]
        public ICompanyRepository CompanyItems { get; set; }

        [HttpPost]
        public IActionResult Create([FromBody]CompanyItem company)
        {
            var newCompanyWithId = _repo.Add(company);
            return this.Ok(newCompanyWithId);
        }

        [HttpGet]
        public IActionResult Get()
        {
            var companies = _repo.GetAll();

            if (companies != null && companies.Any())
                return this.Ok(companies);
            else
                return this.HttpNotFound();

        }

        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            var company = _repo.Find(id);

            if (company == null)
                return this.HttpNotFound();

            return this.Ok(company);
        }

        [HttpGet("name/{name}")]
        public IActionResult GetByName(string name)
        {
            var company = _repo.Find(name);

            if (company == null)
                return this.HttpNotFound();

            return this.Ok(company);
        }

        [HttpGet("search/{name}")]
        public IActionResult SearchByName(string name)
        {
            var company = _repo.Search(name);

            if (company == null)
                return this.HttpNotFound();

            return this.Ok(company);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _repo.Remove(id);

            return this.Ok();
        }


    }
}
