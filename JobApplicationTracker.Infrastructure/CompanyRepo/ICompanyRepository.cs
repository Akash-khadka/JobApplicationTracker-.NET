using JobApplicationTracker.Domain.Models;

namespace JobApplicationTracker.Infrastructure.CompanyRepo
{
    public interface ICompanyRepository
    {
        public int CompanyRegistration(Company company);
    }
}
