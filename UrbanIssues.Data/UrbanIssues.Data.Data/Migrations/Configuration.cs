namespace UrbanIssues.Data.Data.Migrations
{
	using System;
	using System.Linq;
	using System.Data.Entity.Migrations;
	using Models;
	using Microsoft.AspNet.Identity.EntityFramework;
	using System.Collections.Generic;
	using System.Security.Claims;
	using Microsoft.AspNet.Identity;

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
			var sofia = new City
			{
				Name = "Sofia"
			};
			context.Cities.Add(sofia);

			var plovdiv = new City
			{
				Name = "Plovdiv"
			};
			context.Cities.Add(plovdiv);

			var varna = new City
			{
				Name = "Varna"
			};
			context.Cities.Add(varna);

			var burgas = new City
			{
				Name = "Burgas"
			};
			context.Cities.Add(burgas);

			context.SaveChanges();
		}

		private void SeedCategories(UrbanIssuesDbContext context)
		{
			var infrastructure = new Category
			{
				Name = "Infrastructure"
			};

			context.Categories.Add(infrastructure);

			var electricity = new Category
			{
				Name = "Electricity"
			};

			context.Categories.Add(electricity);

			var streetDogs = new Category
			{
				Name = "Street Dogs"
			};

			context.Categories.Add(streetDogs);

			var buildings = new Category
			{
				Name = "Buildings"
			};
			context.Categories.Add(buildings);

            var other = new Category
            {
                Name = "Other"
            };
		    context.Categories.Add(other);

            context.SaveChanges();

		}
	}
}
