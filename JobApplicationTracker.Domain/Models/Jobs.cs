using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobApplicationTracker.Domain.Models
{
    public class Job
    {
        public int JobId { get; set; }
        public string JobTitle { get; set; }
        public string Location { get; set; }
        public string JobDescription { get; set; }
        public string Experience { get; set; }
        public decimal Salary { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CompanyId { get; set; }
        public Company? Company { get; set; }
    }
}
