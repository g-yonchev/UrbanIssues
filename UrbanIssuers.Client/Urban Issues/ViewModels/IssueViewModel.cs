using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrbanIssues.ViewModels
{
	public class IssueViewModel
	{
		public string User { get; set; }

		public string Url { get; set; }

		public DateTime CreatedOn { get; set; }

		public int Likes { get; set; }

		public string City { get; set; }

		public string Category { get; set; }
	}
}
