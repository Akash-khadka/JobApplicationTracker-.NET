using JobApplicationTracker.Application.DTOs;
using JobApplicationTracker.Domain.Models;
using JobApplicationTracker.Infrastructure.CompanyRepo;
using log4net;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace JobApplicationTracker.Application.CompanyService
{
    public class CompanyServices : ICompanyServices
    {
        private readonly ILog log = LogManager.GetLogger(typeof(CompanyServices));
        private readonly ICompanyRepository repo;
        public CompanyServices(ICompanyRepository _repo)
        {
            repo = _repo;
        }

        public Response DeactivateAccount(CompanyDeletionRequest request)
        {
            var response = new Response
            {
                ResponseCode = 101,
                ResponseMessage = "Company Deletion Failed"
            };
            try
            {
                int repResp = repo.DeactivateAccount(request.CompanyId);
                if (repResp != 0)
                {
                    response.ResponseCode = 100;
                    response.ResponseMessage = "Company Deletion successful";
                }
              
            }
            catch (Exception ex)
            {
                log.DebugFormat("Exception Occurred while trying CompanyRegistration| Message: {0}", ex.Message);
                response.ResponseCode = 102;
                response.ResponseMessage = "Exception Occurred during CompanyRegistration!";
            }
            return response;
        }

        public CompanyRegistrationResponse CompanyRegistration(CompanyRegistrationRequest request)
        {
            var response = new CompanyRegistrationResponse
            {
                ResponseCode = 101,
                ResponseMessage = "Company Registration Failed"
            };

            try
            {
                var company = new Company
                {
                    CompanyName= request.CompanyName,
                    Contact= request.Contact,
                    CompanyInfo= request.CompanyInfo,
                    Email= request.Email,
                    Address= request.Address
                                        
                };
                int repResp = repo.CompanyRegistration(company);

                if (repResp != 0)
                {
                    response.ResponseCode = 100;
                    response.ResponseMessage = "Company registration successful";
                    response.CompanyId = repResp;
                }
                
            }
            catch(Exception ex)
            {
                log.DebugFormat("Exception Occurred while trying CompanyRegistration| Message: {0}", ex.Message);
                response.ResponseCode = 102;
                response.ResponseMessage = "Exception Occurred during CompanyRegistration!";
            }
            return response;
        }
    }
}
