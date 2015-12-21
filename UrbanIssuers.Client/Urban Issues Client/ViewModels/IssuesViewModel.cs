namespace Urban_Issues_Client.ViewModels
{
    using System;
    using System.Collections.Generic;
    using Data;
    using Pages;
    using IssueViewModel = Data.Models.IssueViewModel;

    public class IssuesViewModel
    {
        public IList<IssueViewModel> Issues { get; set; }

        public IssuesViewModel()
        {
            this.Issues = new List<IssueViewModel>();
            //Data.GetIssues(LoginResultToken)
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
