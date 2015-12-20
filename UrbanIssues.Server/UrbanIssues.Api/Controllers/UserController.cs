namespace UrbanIssues.Api.Controllers
{
    using UrbanIssues.Data.Data.Repositories;
    public class UserController : BaseController
	{
		public UserController(IUrbanIssuesData data)
			: base(data)
		{
		}
	}
}