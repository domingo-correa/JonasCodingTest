﻿using System;
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
        public IEnumerable<CompanyDto> GetAll()
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
        public async Task<IActionResult> Post([FromBody] Company company)
        {
            await _companyService.AddCompany(company);
            return Ok(new { message = "Company successfully created" });
        }

        // PUT api/<controller>/5
        [HttpPut("{id:int}")]
        public void Put(int id, [FromBody] Company company)
        {
            await _companyService.AddCompany(company);
            return Ok(new { message = "Company successfully updated" });
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id:int}")]
        public void Delete(int id)
        {
        }
    }
}
