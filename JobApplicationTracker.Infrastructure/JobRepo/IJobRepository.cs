using JobApplicationTracker.Domain.Models;

namespace JobApplicationTracker.Infrastructure.JobRepo
{
    public interface IJobRepository
    {
        public int EditJob(Job job);
        public List<Job> GetMyPostedJobs(int companyId);
        public int PostJob(Job job);
    }
}
