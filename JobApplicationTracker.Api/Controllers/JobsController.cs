using JobApplicationTracker.Application.DTOs;
using JobApplicationTracker.Application.JobServices;
using log4net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace JobApplicationTracker.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobsController : ControllerBase
    {
        private readonly IJobServices service;
        public JobsController(IJobServices _service)
        {
            service = _service;
        }
        private readonly ILog log= LogManager.GetLogger(typeof(JobsController)); 
        
        
        [HttpPost]
        [Route("PostJob")]
        public IActionResult PostJob(JobsPostRequest request)
        {
            log.DebugFormat("Job Post Requested For Company : {0} | Request: {1}", request.CompanyId, JsonSerializer.Serialize(request));
            var response= service.PostJob(request);
            return Ok(response);
        }
    }
}
