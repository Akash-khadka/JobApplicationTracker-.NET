using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace JobApplicationTracker.Application.DTOs
{
    public class CompanyRegistrationRequest
    {
        public string CompanyName { get; set; }
        public string? CompanyInfo { get; set; }
        public string Address { get; set; }
        public string Contact { get; set; }
        public string Email { get; set; }
    }

    public class CompanyRegistrationResponse : Response
    {
        public int CompanyId { get; set; }
    }
}
