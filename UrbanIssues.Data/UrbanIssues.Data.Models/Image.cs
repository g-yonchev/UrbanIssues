using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrbanIssues.Data.Models
{
	public class Image
	{
		public int Id { get; set; }

		public byte[] Content { get; set; }

		public string UrlPath { get; set; }

		public int IssueId { get; set; }

		public Issue Issue { get; set; }
	}
}
