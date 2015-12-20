namespace UrbanIssues.Api.Controllers
{
    using System.Linq;
    using System.Web.Http;
    using UrbanIssues.Api.Models.Issues;
    using UrbanIssues.Data.Data.Repositories;

    [RoutePrefix("api/cities")]
    public class CitiesController : BaseController
    {
        public CitiesController(IUrbanIssuesData data)
            : base(data)
        {
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            return this.Ok(this.Data.Cities.All());
        }

        [HttpGet]
        public IHttpActionResult Cities(string city)
        {
            var issues = this.Data.Issues.All().Where(i => i.City.Name == city).Take(10).Select(i => new ResponseIssueModel
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