using Dapper;
using DapperASP.NETCore.Context;
using ModelLayer.Dto;
using RepositoryLayer.Entities;
using RepositoryLayer.Interfaces;
using System.Data;

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


        public async Task<Company> GetCompany(int id)
        {
            var query = "SELECT * FROM Companies WHERE Id = @Id";
            using (var connection = _context.CreateConnection())
            {
                var company = await connection.QuerySingleOrDefaultAsync<Company>(query, new { id });
                return company;
            }
        }


        public async Task<Company> CreateCompany(CompanyDto companyDto)
        {
            var query = "INSERT INTO Companies " +
                             "(Name, Address, Country)" +
                             " VALUES (@Name, @Address, @Country)" +
                             "SELECT CAST(SCOPE_IDENTITY() as int)";

            var parameters = new DynamicParameters();
            parameters.Add("Name", companyDto.Name, DbType.String);
            parameters.Add("Address", companyDto.Address, DbType.String);
            parameters.Add("Country", companyDto.Country, DbType.String);

            using (var connection = _context.CreateConnection())
            {
                var id = await connection.QuerySingleAsync<int>(query, parameters);
                var createdCompany = new Company
                {
                    Id = id,
                    Name = companyDto.Name,
                    Address = companyDto.Address,
                    Country = companyDto.Country
                };
                return createdCompany;
            }

        }
    }



}

