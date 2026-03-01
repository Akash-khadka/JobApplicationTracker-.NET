using JobApplicationTracker.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobApplicationTracker.Infrastructure.CompanyRepo
{
    public interface ICompanyRepository
    {
        public int CompanyRegistration(Company company);
    }
}
