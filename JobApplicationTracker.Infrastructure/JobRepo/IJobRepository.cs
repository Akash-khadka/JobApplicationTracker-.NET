using JobApplicationTracker.Domain.Models;

namespace JobApplicationTracker.Infrastructure.JobRepo
{
    public interface IJobRepository
    {
        public int PostJob(Job job);
    }
}
