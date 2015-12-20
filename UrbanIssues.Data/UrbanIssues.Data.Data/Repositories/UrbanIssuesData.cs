namespace UrbanIssues.Data.Data.Repositories
{
	using System;
	using System.Collections.Generic;
	using UrbanIssues.Data.Models;
	using System.Data.Entity;
	using System.Linq;

	public class UrbanIssuesData : IUrbanIssuesData
	{
		private readonly DbContext context;
		private readonly IDictionary<Type, object> repositories;

		public UrbanIssuesData()
		{
			this.context = new UrbanIssuesDbContext();
			this.repositories = new Dictionary<Type, object>();
		}

		public IRepository<User> Users
		{
			get
			{
				return this.GetRepository<User>();
			}
		}

		public IRepository<Issue> Issues
		{
			get
			{
				return this.GetRepository<Issue>();
			}
		}

		public IRepository<Category> Categories
		{
			get
			{
				return this.GetRepository<Category>();
			}
		}

		public IRepository<Comment> Comments
		{
			get
			{
				return this.GetRepository<Comment>();
			}
		}

		public IRepository<City> Cities
		{
			get
			{
				return this.GetRepository<City>();
			}
		}

		public IRepository<Image> Images
		{
			get
			{
				return this.GetRepository<Image>();
			}
		}

		public int SaveChanges()
		{
			return this.context.SaveChanges();
		}

		private IRepository<T> GetRepository<T>() where T : class
		{
			var typeOfRepository = typeof(T);

			if (!this.repositories.ContainsKey(typeOfRepository))
			{
				var newRepository = Activator.CreateInstance(typeof(EfRepository<T>), this.context);
				this.repositories.Add(typeOfRepository, newRepository);
			}

			return (IRepository<T>)this.repositories[typeOfRepository];
		}
	}
}
