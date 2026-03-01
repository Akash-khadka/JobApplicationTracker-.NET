using JobApplicationTracker.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobApplicationTracker.Infrastructure.JobRepo
{
    public interface IJobRepository
    {
        public int PostJob(Job job);
    }
}
