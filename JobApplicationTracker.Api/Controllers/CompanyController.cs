using JobApplicationTracker.Application.CompanyService;
using JobApplicationTracker.Application.DTOs;
using log4net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
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
        [Route("CompanyRegistration")]
        public IActionResult CompanyRegistration(CompanyRegistrationRequest request)
        {
            log.InfoFormat("Company registration Request For Company :{0} | Request: {1}", request.CompanyName ,JsonSerializer.Serialize(request));
            var response = service.CompanyRegistration(request);
            return Ok(response);
        }
    }
}
