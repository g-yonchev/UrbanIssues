namespace Urban_Issues_Client.Data.Models
{
    using System;
    public class AddIssueModel
    {
        public string City { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        //public string Image { get; set; }
        public string Category { get; set; }
    }
}
