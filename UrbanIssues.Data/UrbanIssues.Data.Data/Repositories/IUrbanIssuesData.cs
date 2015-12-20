using UrbanIssues.Data.Models;

namespace UrbanIssues.Data.Data.Repositories
{
	public interface IUrbanIssuesData
	{
		IRepository<User> Users { get; }

		IRepository<Issue> Issues { get; }

		IRepository<Category> Categories { get; }

		IRepository<City> Cities { get; }

		IRepository<Comment> Comments { get; }

		IRepository<Image> Images { get; }

		int SaveChanges();
	}
}
