using System.Collections.Generic;
using BusinessLayer.Model.Models;

namespace BusinessLayer.Model.Interfaces
{
    public interface ICompanyService
    {
        Task<IEnumerable<CompanyInfo>> GetAllCompanies();
        Task<CompanyInfo?> GetCompanyByCode(string companyCode);
        Task<CompanyInfo> AddCompany(CompanyInfo addCompany);
        Task<CompanyInfo> UpdateCompany(int id, CompanyInfo updateCompany);
        Task<bool> DeleteCompany(int id);
    }
}
