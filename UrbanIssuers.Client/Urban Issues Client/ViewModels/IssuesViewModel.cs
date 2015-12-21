namespace Urban_Issues_Client.ViewModels
{
    using System;
    using System.Collections.Generic;
    using Data.Models;

    public class IssuesViewModel
    {
        public IList<IssueViewModel> Issues { get; set; }

        public IssuesViewModel()
        {
            this.Issues = new List<IssueViewModel>();
            Issues.Add(new IssueViewModel()
            {
                Title = "davam mu pak",
                Category = "asdasd",
                Image = "oo",
                Likes = "aaa",
                User = "aaaaaa"
            });
            Issues.Add(new IssueViewModel()
            {
                Title = "opalqnka",
                Category = "asdasd",
                Image = "oo",
                Likes = "aaa",
                User = "aaaaaa"
            });
        }
    }
}
