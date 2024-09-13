using System;
using System.Collections.Generic;
using System.Web.Http;
using AutoMapper;
using BusinessLayer.Model.Interfaces;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class CompanyController : ApiController
    {
        private readonly ICompanyService _companyService;
        private readonly IMapper _mapper;

        public CompanyController(ICompanyService companyService, IMapper mapper)
        {
            _companyService = companyService;
            _mapper = mapper;
        }
        
        // GET api/<controller>
        [HttpGet]
        public async Task<IEnumerable<CompanyDto>> GetAll()
        {
            var items = _companyService.GetAllCompanies();
            return _mapper.Map<IEnumerable<CompanyDto>>(items);
        }

        // GET api/<controller>/5
        [HttpGet("{companyCode:string}")]
        public CompanyDto Get(string companyCode)
        {
            var item = _companyService.GetCompanyByCode(companyCode);
            return _mapper.Map<CompanyDto>(item);
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody] Company company)
        {
            if (employee == null)
                return BadRequest();

            var createdCompany = await _companyService.AddCompany(company);

            return CreatedAtAction(nameof(Get),
                new { companyCode = createdCompany.companyCode }, createdCompany);
        }

        // PUT api/<controller>/5
        [HttpPut"{id:int}"]
        public void Put(int id, [FromBody] Company company)
        {
            if (id != company.companyCode)
                return BadRequest("Company code not found");

            var companyToUpdate = await _companyService.GetCompany(id);

            if (companyToUpdate == null)
                return NotFound($"Company code = {id} not found");

            return await _companyService.UpdateCompany(company);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id:int}")]
        public void Delete(int id)
        {
            var companyToDelete = await _companyService.GetCompany(id);

            if (companyToDelete == null)
            {
                return NotFound($"Company with Id = {id} not found");
            }

            return await _companyService.DeleteCompany(id);
        }
    }
}
