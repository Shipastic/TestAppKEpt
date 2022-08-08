using Domain.Logic.MappingDTO;
using Domain.Logic.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace TespAppForKEPT.Controllers
{
    public class CompanyController : BaseController
    {
        private readonly IService<CompanyDTO> _serviceCompanyDTO;
        public CompanyController(IService<CompanyDTO> serviceCompanyDTO)
        {
            _serviceCompanyDTO = serviceCompanyDTO;
        }

        [HttpGet]
        [Route("GetCompanies")]
        public async Task<IActionResult> Companies()
        {
            var companies = await _serviceCompanyDTO.GetAllAsync();
            if(companies == null)
            {
                return NotFound();
            }
            return Ok(companies);
        }

        [HttpGet]
        [Route("GetCompany")]
        public async Task<IActionResult> Company([FromQuery]string companyName)
        {
            var company = await _serviceCompanyDTO.GetByNameAsync(companyName);
            if(company == null)
            {
                return NotFound();
            }
            return Ok(company);
        }

        [HttpPost]
        [Route("CreateCompany")]
        public void Create([FromQuery]string companyName, CancellationToken cancellationToken)
        {
           _serviceCompanyDTO.CreateAsync(companyName, cancellationToken);
        }

        [HttpPut]
        [Route("UpdateCompany")]
        public void Update([FromQuery] string companyName, string newCompanyName, CancellationToken cancellationToken)
        {
            _serviceCompanyDTO.UpdateAsync(companyName, newCompanyName, cancellationToken);
        }
    }
}
