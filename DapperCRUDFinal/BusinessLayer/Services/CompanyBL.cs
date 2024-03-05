using BusinessLayer.Interfaces;
using ModelLayer.Dto;
using RepositoryLayer.Entities;
using RepositoryLayer.Interfaces;

namespace BusinessLayer.Services
{
    public class CompanyBL : ICompanyBL
    {
        private readonly ICompanyRL _companyRL;

        public CompanyBL(ICompanyRL companyRL)
        {
            _companyRL = companyRL;
        }


        public Task<IEnumerable<Company>> GetCompanies()
        {
            return _companyRL.GetCompanies();
        }

        public Task<Company> GetCompany(int id)
        {
            return _companyRL.GetCompany(id);
        }

        public Task<Company> CreateCompany(CompanyDto companyDto)
        {
            return _companyRL.CreateCompany(companyDto);
        }

        public Task UpdateCompany(int id, CompanyForUpdateDto company)
        {
            return _companyRL.UpdateCompany(id, company);

        }

        public Task DeleteCompany(int id)
        {
            return _companyRL.DeleteCompany(id);
        }
    }
}
