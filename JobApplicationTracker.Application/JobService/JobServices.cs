using JobApplicationTracker.Application.DTOs;
using JobApplicationTracker.Domain.Models;
using JobApplicationTracker.Infrastructure.JobRepo;
using log4net;
using System.Net;

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

        public JobsPostResponse EditJob(PostedJobs request)
        {
            var jobResponse = new JobsPostResponse
            {
                ResponseMessage = "Edit Job Failed",
                ResponseCode = 101

            };
            try
            {

                var job = new Job
                {
                    JobId = request.JobId,
                    JobDescription = request.JobDescription,
                    JobTitle = request.JobTitle,
                    CompanyId = request.CompanyId,
                    Experience = request.Experience,
                    Location = request.Location,
                    Salary = request.Salary

                };
                int repResponse = repo.EditJob(job);
                if (repResponse != 0)
                {

                    jobResponse.JobReferenceNo = repResponse;
                    jobResponse.ResponseCode = 100;
                    jobResponse.ResponseMessage = "Job Edited Successfully";

                }
                else
                {
                    log.DebugFormat("Edit Job Failed For Company: {0}", request.CompanyId);
                }
            }
            catch (Exception ex)
            {

                jobResponse.ResponseCode = 102;
                jobResponse.ResponseMessage = "Exception Occurred!";
                log.DebugFormat("Exception Occurred while Editing Job: {0}", ex.Message);
            }

            return jobResponse;
        }

        public GetMyPostedJobsResponse GetMyPostedJobs(GetMyJobsRequest request)
        {
            var response = new GetMyPostedJobsResponse
            {
                ResponseCode = 101,
                ResponseMessage="Failed To GetMyPostedJobs"
            };
            try
            {
                var jobList = new List<PostedJobs>();
                var repResp = repo.GetMyPostedJobs(request.CompanyId);
                response.ResponseMessage = "Successful";
                response.ResponseCode = 100;
                if (repResp.Count != 0)
                {
                    var job = new PostedJobs(); 
                    foreach(var repoJob in repResp)
                    {
                        job.JobId= repoJob.JobId;
                        job.JobTitle= repoJob.JobTitle;
                        job.JobDescription = repoJob.JobDescription;
                        job.Location= repoJob.Location;
                        job.Salary = repoJob.Salary;
                        job.CompanyId = repoJob.CompanyId;
                        job.Experience = repoJob.Experience;
                        jobList.Add(job);
                    }
                    response.Jobs = jobList;
                }
                
            }
            catch (Exception ex)
            {
                response.ResponseCode = 102;
                response.ResponseMessage = "Exception Occurred!";
                log.DebugFormat("Exception Occurred while calling GetMyPostedJobs: {0}", ex.Message);
            }
            return response;
        }

        public JobsPostResponse PostJob(JobsPost request)
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
