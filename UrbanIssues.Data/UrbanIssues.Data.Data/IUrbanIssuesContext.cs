using UrbanIssues.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrbanIssues.Data.Data
{
	public interface IUrbanIssuesDbContext
	{
		IDbSet<Issue> Issues { get; set; }

		IDbSet<Category> Categories { get; set; }

		IDbSet<City> Cities { get; set; }

		IDbSet<Comment> Comments { get; set; }

		IDbSet<Image> Images { get; set; }

		DbSet<TEntity> Set<TEntity>() where TEntity : class;

		DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity)
			where TEntity : class;

		void Dispose();

		int SaveChanges();
	}
}
