namespace UrbanIssuesClient.ViewModels
{
    using System;
    using System.Collections.Generic;

    public class IssuesViewModel
    {
        public IEnumerable<IssueViewModel> Issues { get; set; }
    }

    public class IssueViewModel
    {
        public string User { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public string Likes { get; set; }
        public string Category { get; set; }
    }
}
