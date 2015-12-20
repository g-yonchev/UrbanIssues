using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrbanIssues.Data.Models
{
	public class Comment
	{
		public int Id { get; set; }

		public string Content { get; set; }

		public string UserId { get; set; }

		public virtual User User { get; set; }

		public int IssueId { get; set; }

		public virtual Issue Issue { get; set; }
	}
}
