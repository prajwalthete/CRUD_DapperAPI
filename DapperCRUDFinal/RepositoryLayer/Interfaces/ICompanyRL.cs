﻿using ModelLayer.Dto;
using RepositoryLayer.Entities;


namespace RepositoryLayer.Interfaces
{
    public interface ICompanyRL
    {
        public Task<IEnumerable<Company>> GetCompanies();
        public Task<Company> GetCompany(int id);
        public Task<Company> CreateCompany(CompanyDto companyDto);
        public Task UpdateCompany(int id, CompanyForUpdateDto company);
        public Task DeleteCompany(int id);

    }
}

