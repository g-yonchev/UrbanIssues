using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UrbanIssues.Api.Models.Pictures;

namespace UrbanIssues.Api.Models.Issues
{
	public class RequestIssueModel
	{
		public string Description { get; set; }

		public ICollection<string> Images { get; set; }

		public string City { get; set; }

		public string Category { get; set; }
	}
}