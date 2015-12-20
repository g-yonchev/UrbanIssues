using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UrbanIssues.Api.Models.Comments;

namespace UrbanIssues.Api.Models.Issues
{
	public class ResponseIssueDetailModel
	{
		public string User { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

		public ICollection<string> Images { get; set; }

		public DateTime CreatedOn { get; set; }

		public int Likes { get; set; }

		public string City { get; set; }

		public string Category { get; set; }

		public ICollection<ResponseCommentModel> Comments { get; set; }
	}
}