using JobApplicationTracker.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobApplicationTracker.Application.JobServices
{
    public interface IJobServices
    {
        public JobsPostResponse PostJob(JobsPostRequest request);
    }
}
