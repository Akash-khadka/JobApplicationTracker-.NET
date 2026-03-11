using JobApplicationTracker.Domain.Models;
using JobApplicationTracker.Infrastructure.Persistence;
using log4net;
using Microsoft.EntityFrameworkCore;
using System.Net;

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

        public int EditCompany(Company request)
        {
            try
            {
                var company = context.Company.FirstOrDefault(c => c.Id == request.Id);
                if (company == null) { return 0; }
                else
                {
                    company.CompanyName = request.CompanyName;
                    company.CompanyInfo= request.CompanyInfo;
                    company.Address = request.Address;
                    company.Contact = request.Contact;
                    company.Email = request.Email;
                    return context.SaveChanges();
                }
            }            
            catch(Exception ex)
            {
                log.ErrorFormat("Exception Occurred During Edit Job| Exception: {0}", ex.Message);
                throw;
            }
            throw new NotImplementedException();
        }
    }
}
