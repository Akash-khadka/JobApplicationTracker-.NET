using JobApplicationTracker.Domain.Models;
using JobApplicationTracker.Infrastructure.Persistence;
using log4net;

namespace JobApplicationTracker.Infrastructure.JobRepo
{
    public class JobRepository: IJobRepository
    {
        private readonly AppDbContext context;
        private ILog log= LogManager.GetLogger(typeof(JobRepository));
        public JobRepository(AppDbContext _context)
        {
            context= _context;
        }
        public int PostJob(Job job)
        {
            try
            {
                context.Job.Add(job);
                context.SaveChanges();
                log.DebugFormat("Post Job Successful for Company: {0}", job.CompanyId);
                return job.JobId; //only runs if SaveChanges() succeeds
            }
            catch (Exception ex)
            {
                log.ErrorFormat("Exception: {0}", ex.Message);
                throw new InvalidOperationException("Exception Occurred!");

            }
            
        }
    }
}
