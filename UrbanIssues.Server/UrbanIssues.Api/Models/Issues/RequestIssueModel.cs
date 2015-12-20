namespace UrbanIssues.Api.Models.Issues
{
    using System.Collections.Generic;
    public class RequestIssueModel
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public ICollection<string> Images { get; set; }

        public string City { get; set; }

        public string Category { get; set; }
    }
}