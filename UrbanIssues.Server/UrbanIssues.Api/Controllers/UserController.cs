using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UrbanIssues.Data.Data.Repositories;

namespace UrbanIssues.Api.Controllers
{
	public class UserController : BaseController
	{
		public UserController(IUrbanIssuesData data)
			: base(data)
		{
		}
	}
}