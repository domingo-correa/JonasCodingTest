using System.Collections.Generic;
using BusinessLayer.Model.Models;

namespace BusinessLayer.Model.Interfaces
{
    public interface ICompanyService
    {
        Task<IEnumerable<CompanyInfo>> GetAllCompanies();
        Task<CompanyInfo?> GetCompanyByCode(string companyCode);
        Task<CompanyInfo> AddCompany(AddCompany request);
        Task<CompanyInfo> UpdateCompany(int id, UpdateCompany request);
        Task<bool> DeleteCompany(int id);
    }
}
