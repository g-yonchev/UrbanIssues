namespace UrbanIssues.Api.Controllers
{
    using System.Linq;
    using System.Web.Http;
    using UrbanIssues.Api.Models.Issues;
    using UrbanIssues.Data.Data.Repositories;
    [RoutePrefix("api/categories")]
    public class CategoriesController : BaseController
    {
        public CategoriesController(IUrbanIssuesData data)
            : base(data)
        {
        }

        [HttpGet]
        public IHttpActionResult Get(string category)
        {
            var issues = this.Data.Issues.All().Where(i => i.Category.Name == category).Take(10).Select(i => new ResponseIssueModel
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
    }
}