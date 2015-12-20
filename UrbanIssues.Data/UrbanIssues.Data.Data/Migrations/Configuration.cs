namespace UrbanIssues.Data.Data.Migrations
{
    using System.Data.Entity.Migrations;
    using Models;

    public sealed class Configuration : DbMigrationsConfiguration<UrbanIssuesDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(UrbanIssuesDbContext context)
        {
            this.SeedCategories(context);
            this.SeedCities(context);
        }

        private void SeedCities(UrbanIssuesDbContext context)
        {
            context.Cities.AddOrUpdate(x => x.Id,
                new City() { Id = 1, Name = "Sofia" },
                new City() { Id = 2, Name = "Plovdiv" },
                new City() { Id = 3, Name = "Varna" },
                new City() { Id = 4, Name = "Burgas" });

            context.SaveChanges();
        }

        private void SeedCategories(UrbanIssuesDbContext context)
        {

            context.Categories.AddOrUpdate(x => x.Id, 
                new Category() {Id = 1, Name = "Infrastructure"},
                new Category() { Id = 2, Name = "Electricity" },
                new Category() { Id = 3, Name = "Street Dogs" },
                new Category() { Id = 4, Name = "Buildings" },
                new Category() { Id = 5, Name = "Other" });

            context.SaveChanges();

        }
    }
}