namespace UrbanIssues.Data.Data.Repositories
{
    using UrbanIssues.Data.Models;

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
