namespace UrbanIssues.Api.Controllers
{
	using System.Web.Http;

	using UrbanIssues.Data.Data.Repositories;

	/// <summary>
	/// Base controller to pass IUrbanIssuesData to child controlleers 
	/// </summary>
	public class BaseController : ApiController
	{
		protected IUrbanIssuesData Data;

		public BaseController(IUrbanIssuesData data)
		{
			this.Data = data;
		}
	}
}