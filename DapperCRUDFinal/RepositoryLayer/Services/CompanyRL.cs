using Dapper;
using DapperASP.NETCore.Context;
using RepositoryLayer.Entities;
using RepositoryLayer.Interfaces;

namespace RepositoryLayer.Services
{
    public class CompanyRL : ICompanyRL
    {
        private readonly DapperContext _context;

        public CompanyRL(DapperContext context)
        {
            _context = context;
        }



        public async Task<IEnumerable<Company>> GetCompanies()
        {
            var query = "SELECT * FROM Companies";

            using (var connection = _context.CreateConnection())
            {
                var companies = await connection.QueryAsync<Company>(query);
                return companies.ToList();
            }
        }


    }
}
