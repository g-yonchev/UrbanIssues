using UrbanIssues.Data.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace UrbanIssues.Data.Data
{
	public class UrbanIssuesDbContext : IdentityDbContext<User>, IUrbanIssuesDbContext
	{
		public UrbanIssuesDbContext()
			: base("UrbanIssues")
		{
		}

		public virtual IDbSet<Category> Categories { get; set; }

		public virtual IDbSet<City> Cities { get; set; }

		public virtual IDbSet<Comment> Comments { get; set; }

		public virtual IDbSet<Image> Images { get; set; }

		public virtual IDbSet<Issue> Issues { get; set; }

		public static UrbanIssuesDbContext Create()
		{
			return new UrbanIssuesDbContext();
		}

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
		}
	}
}
