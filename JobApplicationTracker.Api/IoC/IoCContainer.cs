using JobApplicationTracker.Application.CompanyService;
using JobApplicationTracker.Application.JobServices;
using JobApplicationTracker.Infrastructure.CompanyRepo;
using JobApplicationTracker.Infrastructure.JobRepo;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobApplicationTracker.Infrastructure.IoC
{
    public static class IoCContainer
    {
        public static IServiceCollection GetDependencyServices(this IServiceCollection services)
            /*adding this keyword means it and extension method which allows you to add new methods 
            to an existing type without modifying the original type*/
        {
            services.AddScoped<IJobServices, JobServices>();
            services.AddScoped<IJobRepository, JobRepository>();

            services.AddScoped<ICompanyServices, CompanyServices>();
            services.AddScoped<ICompanyRepository, CompanyRepository>();

            return services;
        }
    }
}
