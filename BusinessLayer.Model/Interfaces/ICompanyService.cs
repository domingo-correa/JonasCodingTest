using System.Collections.Generic;
using BusinessLayer.Model.Models;

namespace BusinessLayer.Model.Interfaces
{
    public interface ICompanyService
    {
        Task<IEnumerable<CompanyInfo>> GetAllCompanies();
        Task<CompanyInfo> GetCompanyByCode(string companyCode);
        Task AddCompany(AddCompany request);
        Task UpdateCompanyc(int id, UpdateCompany request);
        Task DeleteCompany(int id);
    }
}
