using JobApplicationTracker.Application.DTOs;
using JobApplicationTracker.Domain.Models;
using JobApplicationTracker.Infrastructure.JobRepo;
using log4net;
using log4net.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace JobApplicationTracker.Application.JobServices
{
    public class JobServices : IJobServices
    {
        private readonly IJobRepository repo;
        private readonly ILog log= LogManager.GetLogger(typeof(JobServices));
        public JobServices(IJobRepository _repo)
        {
            repo = _repo;
        }

        public JobsPostResponse PostJob(JobsPostRequest request)
        {
            var jobResponse = new JobsPostResponse
            {
                ResponseMessage = "Post Job Failed",
                ResponseCode = 101

            };
            try
            {
               
                var job = new Job
                {
                    JobDescription = request.JobDescription,
                    JobTitle = request.JobTitle,
                    CompanyId = request.CompanyId,
                    Experience = request.Experience,
                    Location = request.Location,
                    Salary = request.Salary

                };
                int repResponse = repo.PostJob(job);
                if (repResponse != 0)
                {
                    
                    jobResponse.JobReferenceNo = repResponse;
                    jobResponse.ResponseCode = 100;
                    jobResponse.ResponseMessage = "Job Posted Successfully";
                    
                }
                else
                {
                    log.DebugFormat("Post Job Failed For Company: {0}", request.CompanyId);
                }
            }
            catch(Exception ex) {
                
                jobResponse.ResponseCode = 102;
                jobResponse.ResponseMessage = "Exception Occurred!";
                log.DebugFormat("Exception Occurred while calling Post Job: {0}", ex.Message);
            }

            return jobResponse;

        }
    }
}
