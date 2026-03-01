
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobApplicationTracker.Application.DTOs
{
    public class JobsPostRequest
    {
        public string JobTitle { get; set; }
        public string Location { get; set; }
        public string JobDescription { get; set; }
        public string Experience { get; set; }
        public decimal Salary { get; set; }
        public int CompanyId { get; set; }
        public string? CompanyName { get; set; }
    }

    public class JobsPostResponse : Response
    {
        public int JobReferenceNo { get; set; }
    }
}
