using System.Collections.Generic;
using BusinessLayer.Model.Models;

namespace BusinessLayer.Model.Interfaces
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeInfo>> GetAllEmployees();
        Task<EmployeeInfo?> GetEmployeeById(string employeeId);
        Task AddEmployee(EmployeeInfo addEmployee);
        Task UpdateCEmployee(EmployeeInfo updateEmployee);
        Task DeleteEmployee(int id);
    }
}
