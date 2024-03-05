using BusinessLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;

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
                //log error
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




    }
}
