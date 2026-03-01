using JobApplicationTracker.Application.DTOs;

namespace JobApplicationTracker.Application.JobServices
{
    public interface IJobServices
    {
        public JobsPostResponse PostJob(JobsPostRequest request);
    }
}
