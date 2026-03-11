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

        public List<Job> GetMyPostedJobs(int companyId)
        {
            try
            {
                return context.Job.ToList();
            }
            catch(Exception ex)
            {
                log.ErrorFormat("Exception: {0}", ex.Message);
                throw;
            }
        }

        public int PostJob(Job job)
        {
            try
            {
                context.Job.Add(job);
                context.SaveChanges();
                log.DebugFormat("Post or Edit Job Successful for Company: {0}", job.CompanyId);
                return job.JobId; //only runs if SaveChanges() succeeds
            }
            catch (Exception ex)
            {
                log.ErrorFormat("Exception: {0}", ex.Message);
                throw;
            }
            
        }

        public int EditJob(Job jobRequest)
        {
            try
            {
                var job = context.Job.FirstOrDefault(j => j.JobId == jobRequest.JobId &&
                j.CompanyId == jobRequest.CompanyId);
                if (job == null) { return 0; }
                else
                {
                    job.JobTitle = jobRequest.JobTitle;
                    job.Location = jobRequest.Location;
                    job.JobDescription = jobRequest.JobDescription;
                    job.Experience = jobRequest.Experience;
                    job.Salary = jobRequest.Salary;
                    return context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                log.ErrorFormat("Exception: {0}", ex.Message);
                throw;
            }
        }
    }
}
