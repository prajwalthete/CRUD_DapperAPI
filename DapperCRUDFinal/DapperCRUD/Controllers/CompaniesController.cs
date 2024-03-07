using BusinessLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using ModelLayer.Dto;
using ModelLayer.Resposes;
using RepositoryLayer.Entities;

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

        /*
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
        */

        [HttpGet]
        // public async Task<ActionResult<CreateCompanyResponse<List<Company>>>> GetCompanies()
        public async Task<IActionResult> GetCompanies()
        {
            try
            {
                var companies = await _company.GetCompanies();

                var response = new CreateCompanyResponse<List<Company>>
                {
                    Message = "Companies retrieved successfully",
                    StatusCode = 200, // OK
                    Data = companies.ToList() // Assign the list of companies to the Data property
                };

                return Ok(response);

            }
            catch (Exception ex)
            {
                var response = new CreateCompanyResponse<List<Company>>
                {
                    IsSuccess = false,
                    Message = ex.Message,
                    StatusCode = 404 // Internal Server Error
                };
                return StatusCode(500, response);
            }
        }


        [HttpGet("{id}", Name = "CompanyById")]
        public async Task<IActionResult> GetCompany(int id)
        {
            try
            {
                var company = await _company.GetCompany(id);

                if (company == null)
                {
                    var response = new CreateCompanyResponse<Company>
                    {

                        IsSuccess = false,
                        Message = "Compnay with Given Id Does not exists",
                        StatusCode = 400,

                    };
                    return BadRequest(response);

                }
                {

                    var response = new CreateCompanyResponse<Company>
                    {

                        Message = "Company retrieved successfully",
                        StatusCode = 200,
                        Data = company
                    };

                    return Ok(response);
                }



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
                var response = new CreateCompanyResponse<Company>
                {

                    Message = "Company retrieved successfully",
                    StatusCode = 200,
                    Data = createdCompany
                };

                return CreatedAtRoute("CompanyById", new { id = createdCompany.Id }, response);
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

                var response = new CreateCompanyResponse<Company>
                {

                    Message = "Company Updated successfully",
                    StatusCode = 200,
                    // Data = dbComapny
                };
                return Ok(response);

            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompany(int id)
        {
            try
            {
                var DbCompany = await _company.GetCompany(id);
                if (DbCompany == null)
                    return NotFound();

                await _company.DeleteCompany(id);
                return NoContent();

            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }

        }

    }
}


