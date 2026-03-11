using JobApplicationTracker.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobApplicationTracker.Application.CompanyService
{
    public interface ICompanyServices
    {

        public Response DeactivateAccount(CompanyDeletionRequest request);
        public CompanyRegistrationResponse CompanyRegistration(CompanyRegistrationRequest request);
        public CompanyRegistrationResponse EditCompany(CompanyEditRequest request);
    }
}
