using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UrbanIssues.Api.Models.Issues
{
	public class ResponseIssueModel
	{
		public string User { get; set; }

		public string Image { get; set; }

		public DateTime CreatedOn { get; set; }

		public int Likes { get; set; }

		public string City { get; set; }

		public string Category { get; set; }
	}
}