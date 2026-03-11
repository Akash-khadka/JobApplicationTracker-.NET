using JobApplicationTracker.Application.CompanyService;
using JobApplicationTracker.Application.DTOs;
using log4net;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace JobApplicationTracker.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ILog log = LogManager.GetLogger(typeof(CompanyController));
        private readonly ICompanyServices service;
        public CompanyController(ICompanyServices _service)
        {
            service= _service;
        }

        [HttpPost]
        [Route("RegisterCompany")]
        public IActionResult CompanyRegistration(CompanyRegistrationRequest request)
        {
            log.InfoFormat("Company registration Request For Company :{0} | Request: {1}", request.CompanyName ,JsonSerializer.Serialize(request));
            var response = service.CompanyRegistration(request);
            return Ok(response);
        }


        [HttpPost]
        [Route("DeactivateAccount")]
        public IActionResult DeactivateAccount(CompanyDeletionRequest request)
        {
            log.InfoFormat("Company Account Deactivation Request From Company ID: {0}", request.CompanyId);
            var response = service.DeactivateAccount(request);
            return Ok(response);
        }

        [HttpPost]
        [Route("EditCompanyInfo")]
        public IActionResult EditCompany(CompanyEditRequest request)
        {
            log.InfoFormat("Edit Company Request| Company Id: {0}");
            var response = service.EditCompany(request);
            return Ok(response);
        }
    }
}
