using System;
using System.Collections.Generic;
using System.Web.Http;
using AutoMapper;
using BusinessLayer.Model.Interfaces;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class EmployeeController : ApiController
    {
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;

        public EmployeeController(IEmployeeService employeeService, IMapper mapper)
        {
            _employeeService = employeeService;
            _mapper = mapper;
        }
        
        // GET api/<controller>
        [HttpGet]
        public async Task<IEnumerable<EmployeeDto>> GetAll()
        {
            var items = _employeeService.GetAllEmployees();
            return _mapper.Map<IEnumerable<EmployeeDto>>(items);
        }

        // GET api/<controller>/5
        [HttpGet("{employeeCode:string}")]
        public EmployeeDto Get(string employeeCode)
        {
            var item = _employeeService.GetEmployeeByCode(employeeCode);
            return _mapper.Map<EmployeeDto>(item);
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody] Employee employee)
        {
            if (employee == null)
                return BadRequest();

            var createdEmployee = await _employeeService.AddEmployee(employee);

            return CreatedAtAction(nameof(Get),
                new { employeeCode = createdEmployee.employeeCode }, createdEmployee);
        }

        // PUT api/<controller>/5
        [HttpPut"{id:int}"]
        public void Put(int id, [FromBody] Employee employee)
        {
            if (id != employee.employeeCode)
                return BadRequest("Employee code not found");

            var employeeToUpdate = await _employeeService.GetEmployee(id);

            if (employeeToUpdate == null)
                return NotFound($"Employee code = {id} not found");

            return await _employeeService.UpdateEmployee(employee);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id:int}")]
        public void Delete(int id)
        {
            var employeeToDelete = await _employeeService.GetEmployee(id);

            if (employeeToDelete == null)
            {
                return NotFound($"Employee with Id = {id} not found");
            }

            return await _employeeService.DeleteEmployee(id);
        }
    }
}
