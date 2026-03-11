using JobApplicationTracker.Application.DTOs;
using JobApplicationTracker.Application.JobServices;
using log4net;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace JobApplicationTracker.Api.Controllers
{
    [Route("api/Company/[controller]")]
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
        public IActionResult PostJob(JobsPost request)
        {
            log.DebugFormat("Job Post Requested For Company : {0} | Request: {1}", request.CompanyId, JsonSerializer.Serialize(request));
            var response= service.PostJob(request);
            return Ok(response);
        }

        [HttpPost]
        [Route("GetMyPostedJobs")] 
        public IActionResult GetMyPostedJobs(GetMyJobsRequest request)
        {
            log.DebugFormat("GetMyPostedJobs Request By Company, CompanyId: {0}", request.CompanyId);
            var response = service.GetMyPostedJobs(request);
            return Ok(response);
        }

        [HttpPost]
        [Route("EditJob")]
        public IActionResult EditJob(PostedJobs request)
        {
            log.DebugFormat("Job Edit Request From Company : {0} | Request: {1}");
            var response = service.EditJob(request);
            return Ok();
        }
    }
}
