namespace JobApplicationTracker.Application.DTOs
{
    public class JobsPost 
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
    public class GetMyJobsRequest
    {
        public int CompanyId { get; set; }
    }
    public class GetMyPostedJobsResponse: Response
    {
        public List<PostedJobs>? Jobs { get; set; }
    }
    public class PostedJobs
    {
        public int JobId { get; set; }
        public string? JobTitle { get; set; }
        public string? Location { get; set; }
        public string? JobDescription { get; set; }
        public string? Experience { get; set; }
        public decimal Salary { get; set; }
        public int CompanyId { get; set; }
    }
}
