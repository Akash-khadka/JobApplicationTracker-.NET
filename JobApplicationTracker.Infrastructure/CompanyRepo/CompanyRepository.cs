using JobApplicationTracker.Domain.Models;
using JobApplicationTracker.Infrastructure.Persistence;
using log4net;
using Microsoft.EntityFrameworkCore;

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

        public int DeactivateAccount(int companyId)
        {
            try
            {
                return context.Company.Where(c => c.Id == companyId && c.IsActive)
                    .ExecuteUpdate(s =>
                    s.SetProperty(c => c.IsActive, false));
                
            }
            catch(Exception ex)
            {
                log.DebugFormat("Exception Occurred during Company Deletion| Message: {0}", ex.Message);
                throw;
            }
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
