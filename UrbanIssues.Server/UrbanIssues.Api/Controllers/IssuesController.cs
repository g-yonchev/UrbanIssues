using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using UrbanIssues.Api.Models.Comments;
using UrbanIssues.Api.Models.Issues;
using UrbanIssues.Data.Data.Repositories;
using UrbanIssues.Data.Models;

namespace UrbanIssues.Api.Controllers
{
	[RoutePrefix("api/issues")]
	public class IssuesController : BaseController
	{
		public IssuesController(IUrbanIssuesData data)
			: base(data)
		{
		}

		[HttpGet]
		public IHttpActionResult Get()
		{
			var issues = this.Data.Issues.All().Take(10).Select(i => new ResponseIssueModel
			{
				Category = i.Category.Name,
				City = i.City.Name,
				CreatedOn = i.CreatedOn,
				Likes = i.Likes,
				User = i.User.UserName,
				Image = i.Images.FirstOrDefault().Url
			}).ToList();

			return this.Ok(issues);
		}

		[HttpGet]
		public IHttpActionResult Get(int id)
		{
			var issue = this.Data.Issues.All().Where(i => i.Id == id).FirstOrDefault();

			if (issue == null)
			{
				return this.NotFound();
			}

			var comments = issue.Comments.Select(c => new ResponseCommentModel
			{
				Content = c.Content,
				User = c.User.UserName
			}).Take(5).ToList();

			var urls = issue.Images.Select(img => img.Url).ToList();

			var issueToReturn = new ResponseIssueDetailModel
			{
				Category = issue.Category.Name,
				City = issue.City.Name,
				CreatedOn = issue.CreatedOn,
				Likes = issue.Likes,
				User = issue.User.UserName,
				Images = urls,
				Comments = comments
			};

			return this.Ok(issueToReturn);
		}

		[Authorize]
		[HttpPost]
		public IHttpActionResult Post(RequestIssueModel model)
		{
			var currentUserId = User.Identity.GetUserId();
			var currentUser = this.Data.Users.All().FirstOrDefault(x => x.Id == currentUserId);

			if (currentUser == null)
			{
				return this.BadRequest("Invalid user token! Please login again!");
			}

			if (model == null)
			{
				return this.BadRequest();
			}
			
			var category = this.Data.Categories.All().Where(c => c.Name == model.Category).FirstOrDefault();
			var city = this.Data.Cities.All().Where(c => c.Name == model.City).FirstOrDefault();

			var images = new List<Image>();

			if (model.Images != null)
			{
				foreach (var img in model.Images)
				{
					images.Add(new Image() { Url = img });
				}
			}

			var createdOn = DateTime.Now;
			var issue = new Issue
			{
				Description = model.Description,
				User = currentUser,
				Category = category,
				City = city,
				Images = images,
				CreatedOn = createdOn
			};

			this.Data.Issues.Add(issue);
			this.Data.SaveChanges();

			// return custom view
			return this.Ok(issue.Id);
		}

		// TODO doesnt work?!?!?! I DO NOT KNOW WHY?? WTF?
		[HttpPost]
		[Authorize]
		[Route("comment/{id}")]
		public IHttpActionResult Post(int id, RequestCommentModel model)
		{
			var currentUserId = User.Identity.GetUserId();
			var currentUser = this.Data.Users.All().FirstOrDefault(x => x.Id == currentUserId);

			if (currentUser == null)
			{
				return this.BadRequest("Invalid user token! Please login again!");
			}

			var issue = this.Data.Issues.All().Where(i => i.Id == id).FirstOrDefault();

			if (issue == null)
			{
				return this.BadRequest();
			}

			var newComment = new Comment
			{
				UserId = currentUserId,
				Content = model.Content,
				IssueId = id
			};

			this.Data.Comments.Add(newComment);
			this.Data.SaveChanges();

			return this.Ok();
		}

		[HttpPut]
		[Authorize]
		public IHttpActionResult Put(int id)
		{
			var currentUserId = User.Identity.GetUserId();
			var currentUser = this.Data.Users.All().FirstOrDefault(x => x.Id == currentUserId);

			if (currentUser == null)
			{
				return this.BadRequest("Invalid user token! Please login again!");
			}

			var issue = this.Data.Issues.All().Where(i => i.Id == id).FirstOrDefault();

			if (issue == null)
			{
				return this.BadRequest();
			}

			issue.Likes++;
			this.Data.SaveChanges();
			return this.Ok();
		}
	}
}