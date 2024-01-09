using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Nowadays.BLL.Abstract;
using Nowadays.DTO.Company;
using static CreditRequest.BLL.ValidationRules.CompanyValidation;

namespace Nowadays.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyservice;

        public CompanyController(ICompanyService companyservice)
        {
            _companyservice = companyservice;
        }

        [HttpGet("GetAllCompanies")]
        public IActionResult Get()
        {
            var companies = _companyservice.GetAll();

            return Ok(companies);
        }


        [HttpPost("AddCompany")]
        public async Task<IActionResult> AddCompany(AddCompanyViewModel company)
        {
            AddCompanyValidation cv = new AddCompanyValidation();
            ValidationResult results = cv.Validate(company);

            if (results.IsValid)
            {

                await _companyservice.CompanyAdd(company);

                return Ok();
            }
            else
            {
                var errorList = new List<string>();
                foreach (var item in results.Errors)
                {
                    errorList.Add(item.ErrorMessage);

                }
                return BadRequest(errorList);
            }

        }

        [HttpPut("UpdateCompany")]
        public async Task<IActionResult> UpdateCompany(CompanyEditViewModel company)
        {
            if (company.Id < 1)
            {
                return BadRequest();
            }
            EditCompanyValidation bv = new EditCompanyValidation();
            ValidationResult results = bv.Validate(company);
          
            if (results.IsValid)
            {
                await _companyservice.CompanyUpdate(company);
                return Ok();
            }
            else
            {
                var errorList = new List<string>();
                foreach (var i in results.Errors)
                {
                    errorList.Add(i.ErrorMessage);

                }
                return BadRequest(errorList);
            }

        }

        [HttpDelete("DeleteCompany")]
        public async Task<IActionResult> DeleteCompany(int entityId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            await _companyservice.CompanyRemove(entityId);
            return Ok();
        }

    }
}
