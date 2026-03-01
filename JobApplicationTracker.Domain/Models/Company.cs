using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobApplicationTracker.Domain.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string? CompanyInfo { get; set;}
        public string Contact { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public List<Job>? Jobs { get; set; }
    }
}
