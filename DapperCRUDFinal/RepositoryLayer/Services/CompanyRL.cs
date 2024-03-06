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
            using (var connection = _context.CreateConnection())
            {
                // Check if table exists
                bool tableExists = await connection.QueryFirstOrDefaultAsync<bool>(
                    """ 
                    SELECT COUNT(*) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Companies'
                    """
                    );


                if (!tableExists)
                {
                    // Create table if it doesn't exist
                    await connection.ExecuteAsync("""

                                        CREATE TABLE Companies (
                                            Id INT IDENTITY(1, 1) PRIMARY KEY,
                                            Name NVARCHAR(100) NOT NULL,
                                            Address NVARCHAR(100) NOT NULL,
                                            Country NVARCHAR(100) NOT NULL
                                        )
                        """);
                }

                var query = @"INSERT INTO Companies (Name, Address, Country) VALUES (@Name, @Address, @Country);
                        SELECT CAST(SCOPE_IDENTITY() as int)";

                var parameters = new DynamicParameters();
                parameters.Add("Name", companyDto.Name, DbType.String);
                parameters.Add("Address", companyDto.Address, DbType.String);
                parameters.Add("Country", companyDto.Country, DbType.String);

                var id = await connection.ExecuteScalarAsync<int>(query, parameters);

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


        /*
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
                var id = await connection.ExecuteScalarAsync<int>(query, parameters);
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
        */
        public async Task UpdateCompany(int id, CompanyForUpdateDto company)
        {
            var query = "UPDATE Companies SET Name = @Name, Address = @Address, Country = @Country WHERE Id = @Id";

            var parameters = new DynamicParameters();

            parameters.Add("Id", id, DbType.Int32);
            parameters.Add("Name", company.Name, DbType.String);
            parameters.Add("Address", company.Address, DbType.String);
            parameters.Add("Country", company.Country, DbType.String);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task DeleteCompany(int id)
        {
            var query = """ DELETE FROM Companies WHERE Id=@Id""";

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, new { id });
            }
        }
    }



}

