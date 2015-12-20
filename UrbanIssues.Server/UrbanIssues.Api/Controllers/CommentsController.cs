namespace UrbanIssues.Api.Controllers
{
    using System.Linq;
    using System.Web.Http;
    using Data.Models;
    using Microsoft.AspNet.Identity;
    using Models.Comments;
    using UrbanIssues.Api.Models.Issues;
    using UrbanIssues.Data.Data.Repositories;

    [RoutePrefix("api/comments")]
    public class CommentsController : BaseController
    {
        public CommentsController(IUrbanIssuesData data)
            : base(data)
        {
        }

        [Authorize]
        public IHttpActionResult Post(int issueId, [FromBody]RequestCommentModel model)
        {
            var currentUserId = User.Identity.GetUserId();
            var currentUser = this.Data.Users.All().FirstOrDefault(x => x.Id == currentUserId);

            if (currentUser == null)
            {
                return this.BadRequest("Invalid user token! Please login again!");
            }

            var issue = this.Data.Issues.All().Where(i => i.Id == issueId).FirstOrDefault();

            if (issue == null)
            {
                return this.NotFound();
            }

            var newComment = new Comment
            {
                UserId = currentUserId,
                Content = model.Content,
                IssueId = issueId
            };

            this.Data.Comments.Add(newComment);
            this.Data.SaveChanges();

            return this.Ok();
        }
    }
}