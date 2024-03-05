using BusinessLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using ModelLayer.Dto;

namespace DapperCRUD.Controllers
{
    [Route("api/Companies")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly ICompanyBL _company;

        public CompaniesController(ICompanyBL company)
        {
            _company = company;
        }


        [HttpGet]
        public async Task<IActionResult> GetCompanies()
        {
            try
            {
                var companies = await _company.GetCompanies();
                return Ok(companies);
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }


        [HttpGet("{id}", Name = "CompanyById")]
        public async Task<IActionResult> GetCompany(int id)
        {
            try
            {
                var company = await _company.GetCompany(id);
                if (company == null) return BadRequest("Company with Given Id NOT exists");
                return Ok(company);

            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }


        [HttpPost]
        public async Task<IActionResult> CreateCompany(CompanyDto company)
        {
            try
            {
                var createdCompany = await _company.CreateCompany(company);
                return CreatedAtRoute("CompanyById", new { id = createdCompany.Id }, createdCompany);
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCompany(int id, CompanyForUpdateDto companyForUpdateDto)
        {
            try
            {
                var dbComapny = await _company.GetCompany(id);
                if (dbComapny == null)
                    return NotFound();

                await _company.UpdateCompany(id, companyForUpdateDto);
                return NoContent();

            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }


    }
}


