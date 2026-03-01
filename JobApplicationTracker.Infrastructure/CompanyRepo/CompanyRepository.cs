using JobApplicationTracker.Domain.Models;
using JobApplicationTracker.Infrastructure.Persistence;
using log4net;

namespace JobApplicationTracker.Infrastructure.CompanyRepo
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly AppDbContext context;
        private readonly ILog log= LogManager.GetLogger(typeof(CompanyRepository));
        public CompanyRepository(AppDbContext _context)
        {
            context= _context;
        }

        public int CompanyRegistration(Company company)
        {
            try
            {
                context.Company.Add(company);
                context.SaveChanges();
                log.DebugFormat("Company Registration Successful");
                return company.Id;
            }
            catch (Exception ex)
            {
                log.DebugFormat("Exception Occurred during Company Registration| Message: {0}", ex.Message);
                throw new InvalidOperationException("Exception Occurred!");
            }

        }
    }
}
