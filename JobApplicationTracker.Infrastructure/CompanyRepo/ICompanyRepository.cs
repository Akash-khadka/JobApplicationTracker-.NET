using JobApplicationTracker.Domain.Models;

namespace JobApplicationTracker.Infrastructure.CompanyRepo
{
    public interface ICompanyRepository
    {
        public int DeactivateAccount(int companyId);
        public int CompanyRegistration(Company company);
        public int EditCompany(Company company);
    }
}
