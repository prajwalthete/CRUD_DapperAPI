using BusinessLayer.Interfaces;
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



    }
}
