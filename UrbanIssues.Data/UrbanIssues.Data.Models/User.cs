namespace UrbanIssues.Data.Models
{
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.Security.Claims;
	using System.Threading.Tasks;

	using Microsoft.AspNet.Identity.EntityFramework;
	using Microsoft.AspNet.Identity;

	using Common.Constants;

	public class User : IdentityUser
	{
		// From User Microsofts Identity
		public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager, string authenticationType)
		{
			// Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
			var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
			// Add custom user claims here
			return userIdentity;
		}

		private ICollection<Issue> issues;
		private ICollection<Comment> comments;

		public User()
		{
			this.issues = new HashSet<Issue>();
			this.comments = new HashSet<Comment>();
		}

		public ICollection<Issue> Issues
		{
			get
			{
				return this.issues;
			}
			set
			{
				this.issues = value;
			}
		}

		public ICollection<Comment> Comments
		{
			get
			{
				return this.comments;
			}
			set
			{
				this.comments = value;
			}
		}
	}
}
