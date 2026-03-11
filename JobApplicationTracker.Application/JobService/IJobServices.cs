using JobApplicationTracker.Application.DTOs;

namespace JobApplicationTracker.Application.JobServices
{
    public interface IJobServices
    {
        public JobsPostResponse EditJob(PostedJobs request);
        public GetMyPostedJobsResponse GetMyPostedJobs(GetMyJobsRequest request);
        public JobsPostResponse PostJob(JobsPost request);
    }
}
