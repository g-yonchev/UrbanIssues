namespace UrbanIssues.Api
{
	using System.Data.Entity;
	using UrbanIssues.Data.Data;
	using Data.Data.Migrations;

	public static class DatabaseConfig
	{
		public static void Initialize()
		{
			Database.SetInitializer(new MigrateDatabaseToLatestVersion<UrbanIssuesDbContext, Configuration>());
			UrbanIssuesDbContext.Create().Database.Initialize(true);
		}
	}
}