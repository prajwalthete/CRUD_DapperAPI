using RepositoryLayer.Entities;

namespace BusinessLayer.Interfaces
{
    public interface ICompanyBL
    {
        public Task<IEnumerable<Company>> GetCompanies();



    }
}
